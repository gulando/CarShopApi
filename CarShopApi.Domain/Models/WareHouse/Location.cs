using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace CarShopApi.Domain.Models.WareHouse
{
    public class Location
    {
        [BsonElement("lat")]
        public double Latitude { get; set; }
        
        [BsonElement("long")]
        public double Long { get; set; }
    }
}