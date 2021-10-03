using MongoDB.Bson.Serialization.Attributes;

namespace CarShopApi.Domain.Models.Warehouse
{
    public class Location
    {
        [BsonElement("lat")]
        public double Lat { get; set; }
        
        [BsonElement("long")]
        public double Long { get; set; }
    }
}