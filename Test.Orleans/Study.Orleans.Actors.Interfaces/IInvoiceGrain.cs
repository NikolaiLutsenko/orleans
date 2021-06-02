using Orleans;
using System.Threading.Tasks;

namespace Study.Orleans.Actors.Interfaces
{
    public interface IInvoiceGrain: IGrainWithGuidKey
    {
        Task CreateAsync();
        Task<object> GetInfoAsync();
    }
}
