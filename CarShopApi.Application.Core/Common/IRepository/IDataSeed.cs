using System.Threading;
using System.Threading.Tasks;

namespace CarShopApi.Application.Core.Common.IRepository
{
    public interface IDataSeed
    {
        Task SeedAllInitialDataAsync(CancellationToken cancellationToken = default);
    }
}