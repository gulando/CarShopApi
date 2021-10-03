using System.Collections.Generic;
using System.Threading.Tasks;
using CarShopApi.Domain.Models.Warehouse;
using MongoDB.Bson;

namespace CarShopApi.Application.Core.Common.IRepository
{
    public interface IWarehouseRepository
    {
        Task<ObjectId> Create(Warehouse warHouse);

        Task<Warehouse> Get(ObjectId objectId);
        
        Task<IEnumerable<Warehouse>> Get();
        
        Task<IEnumerable<Warehouse>> GetByName(string name);

        Task<bool> Update(ObjectId objectId, Warehouse warHouse);

        Task<bool> Delete(ObjectId objectId);
    }
}