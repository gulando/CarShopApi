using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarShopApi.Domain.Models.WareHouse
{
    public class Warhouse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public Location Location { get; set; }
        
        [BsonElement("cars")]
        public List<Car> Cars { get; set; }
        
    }
}