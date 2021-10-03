using System.Collections.Generic;
using CarShopApi.Domain.Models.Warehouse;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarShopApi.Domain.Models.Warehouse
{
    public class Warehouse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        
        public Location Location { get; set; }
        
        [BsonElement("cars")]
        public List<Car> Cars { get; set; }
        
    }
}