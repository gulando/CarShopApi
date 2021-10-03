using System;

namespace CarShopApi.ResponseModels
{
    public class VehicleModel
    {
        public string Make { get; set; }
        
        public string Model { get; set; }
        
        public int YearModel { get; set; }
        
        public double Price { get; set; }
        
        public bool Licensed { get; set; }
        
        public DateTime DateAdded { get; set; }
    }
}