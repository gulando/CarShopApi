using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CarShopApi.Application.Core.IRepository;
using CarShopApi.Domain.Models.Warehouse;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarShopApi.Infrastructure.DataSeedModels
{
    public class DataSeed : IDataSeed
    {
        private readonly string _dataSeedJsonFilesRootPath;
        private readonly IMongoCollection<Warehouse> _collection;

        public DataSeed(IMongoClient client, IOptions<DataSeedOptions> dataSeedOptions)
        {
            _dataSeedJsonFilesRootPath = dataSeedOptions.Value.JsonFilesRootPath;
            
            var database = client.GetDatabase(nameof(CarShopApi));
            _collection = database.GetCollection<Warehouse>(nameof(Warehouse));
        }
        
        public async Task SeedAllInitialDataAsync(CancellationToken cancellationToken = default)
        {
            var data = GetWarehouses();
            await _collection.InsertManyAsync(data, cancellationToken: cancellationToken);
        }

        private List<Warehouse> GetWarehouses()
        {
            return ReadSeedDataFromJsonFile<Warehouse>(_dataSeedJsonFilesRootPath, nameof(Warehouse));
        }
        private static List<T> ReadSeedDataFromJsonFile<T>(string path, string fileName)
        {
            var fullPath = Path.Combine(path, $"{fileName}.json");
            var data = File.ReadAllText(fullPath, Encoding.UTF8);

            return JsonSerializer.Deserialize<List<T>>(data);
        }
        
    }
}