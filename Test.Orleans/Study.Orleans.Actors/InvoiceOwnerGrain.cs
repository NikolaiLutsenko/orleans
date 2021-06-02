using Microsoft.EntityFrameworkCore;
using Orleans;
using Study.Orleans.Actors.Interfaces;
using Study.Orleans.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study.Orleans.Actors
{
    public class InvoiceOwnerGrain : Grain, IInvoiceOwnerGrain
    {
        private readonly IGrainFactory _grainFactory;
        private readonly InvoiceDbContext _db;

        private LinkedList<Guid> _invoiceIds;

        public InvoiceOwnerGrain(IGrainFactory grainFactory, InvoiceDbContext db)
        {
            _grainFactory = grainFactory;
            _db = db;
        }

        public async override Task OnActivateAsync()
        {
            await Task.WhenAll(PopulateInvoiceIds());
        }

        public Task<object> GetInvoiceAsync(Guid id)
        {
            if (_invoiceIds.Contains(id))
                return _grainFactory.GetGrain<IInvoiceGrain>(id).GetInfoAsync();
            return null;
        }

        public async Task<object[]> GetInvoicesAsync()
        {
            var ids = await Task.WhenAll(_invoiceIds.Select(id => _grainFactory.GetGrain<IInvoiceGrain>(id).GetInfoAsync()).ToArray());
            return ids;
        }

        public Task AddInvoice(Guid id)
        {
            _invoiceIds.AddFirst(id);
            return Task.CompletedTask;
        }

        private async Task PopulateInvoiceIds()
        {
            var ids = await _db.Invoices
                .Where(x => x.MerchantId == this.GetPrimaryKey())
                .OrderByDescending(x => x.Created)
                .Select(x => x.Id)
                .ToArrayAsync();

            _invoiceIds = new LinkedList<Guid>(ids);
        }
    }
}
