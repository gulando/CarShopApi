using System.Threading;
using System.Threading.Tasks;

namespace CarShopApi.Application.Core.IRepository
{
    public interface IDataSeed
    {
        Task SeedAllInitialDataAsync(CancellationToken cancellationToken = default);
    }
}