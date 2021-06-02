using Orleans;
using System;
using System.Threading.Tasks;

namespace Study.Orleans.Actors.Interfaces
{
    public interface IInvoiceOwnerGrain : IGrainWithGuidKey
    {
        Task<object[]> GetInvoicesAsync();

        Task<object> GetInvoiceAsync(Guid id);

        Task AddInvoice(Guid id);
    }
}
