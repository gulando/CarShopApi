using MongoDB.Bson.Serialization.Attributes;

namespace CarShopApi.Domain.Models.Warehouse
{
    [BsonIgnoreExtraElements]
    public class Car
    {
        [BsonElement("location")]
        public string Location { get; set; }
        
        [BsonElement("vehicles")]
        public Vehicle[] Vehicles { get; set; }
    }
}