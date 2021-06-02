using Microsoft.EntityFrameworkCore;
using Orleans;
using Study.Orleans.Actors.Interfaces;
using Study.Orleans.Data;
using Study.Orleans.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Orleans.Actors
{
    public class InvoiceGrain : Grain, IInvoiceGrain
    {
        public InvoiceGrain(InvoiceDbContext db)
        {
            _db = db;
        }

        public async override Task OnActivateAsync()
        {
            await Task.WhenAll(PopulateInvoiceInfo(), PopulatePayments());
        }

        public Task<object> GetInfoAsync()
        {
            throw new NotImplementedException();
        }

        #region Private

        private async Task PopulateInvoiceInfo()
        {
            _invoice = await _db.Invoices
                .Include(x => x.Items)
                .Include(x => x.Shipping)
                .FirstOrDefaultAsync(i => i.Id == this.GetPrimaryKey());
        }

        private async Task PopulatePayments()
        {
            var ids = await _db
                .Payments
                .Where(x => x.InvoiceId == this.GetPrimaryKey())
                .OrderByDescending(x => x.Created)
                .Select(x => x.Id)
                .ToArrayAsync();

            _paymentIds = new LinkedList<Guid>(ids);
        }

        public Task CreateAsync()
        {
            throw new NotImplementedException();
        }

        private readonly InvoiceDbContext _db;

        private Invoice _invoice;

        private LinkedList<Guid> _paymentIds;

        #endregion
    }
}
