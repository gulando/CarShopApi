using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarShopApi.Domain.Models.Warehouse
{
    [BsonIgnoreExtraElements]
    public class Vehicle
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("make")]
        public string Make { get; set; }
        
        [BsonElement("model")]
        public string Model { get; set; }
        
        [BsonElement("year_model")]
        public int YearModel { get; set; }
        
        [BsonElement("price")]
        public double Price { get; set; }
        
        [BsonElement("licensed")]
        public bool Licensed { get; set; }
        
        [BsonElement("date_added")]
        public DateTime DateAdded { get; set; }
    }
}