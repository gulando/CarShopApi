using System.Collections.Generic;
using System.Threading.Tasks;
using CarShopApi.Application.Core.IRepository;
using CarShopApi.Domain.Models.Warehouse;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarShopApi.Infrastructure.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly IMongoCollection<Warehouse> _collection;

        public WarehouseRepository(IMongoClient client)
        {
            var database = client.GetDatabase(nameof(CarShopApi));
            _collection = database.GetCollection<Warehouse>(nameof(Warehouse));
        }
        
        public async Task<ObjectId> Create(Warehouse warHouse)
        {
            await _collection.InsertOneAsync(warHouse);

            return warHouse.Id;        }

        public Task<Warehouse> Get(ObjectId objectId)
        {
            var filter = Builders<Warehouse>.Filter.Eq(c => c.Id, objectId);
            var warehouse = _collection.Find(filter).FirstOrDefaultAsync();

            return warehouse;
        }

        public async Task<IEnumerable<Warehouse>> Get()
        {
            var warehouses = await _collection.Find(_ => true).ToListAsync();

            return warehouses;
        }

        public async Task<IEnumerable<Warehouse>> GetByName(string name)
        {
            var filter = Builders<Warehouse>.Filter.Eq(c => c.Name, name);
            var warehouses = await _collection.Find(filter).ToListAsync();

            return warehouses;        
        }

        public async Task<bool> Update(ObjectId objectId, Warehouse warHouse)
        {
            var filter = Builders<Warehouse>.Filter.Eq(c => c.Id, objectId);
            var update = Builders<Warehouse>.Update.Set(c => c.Name, warHouse.Name);
            var result = await _collection.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<Warehouse>.Filter.Eq(c => c.Id, objectId);
            var result = await _collection.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }
    }
}