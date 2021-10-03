using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarShopApi.Domain.Models.Warehouse
{
    [BsonIgnoreExtraElements]
    public class Warehouse
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("name")] 
        public string Name { get; set; }

        [BsonElement("location")] 
        public Location Location { get; set; }

        [BsonElement("cars")] 
        public Car Cars { get; set; }
    }
}