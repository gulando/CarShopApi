using System.Collections.Generic;

namespace CarShopApi.ResponseModels
{
    public class CarModel
    {
        public string Location { get; set; }
        
        public List<VehicleModel> VehicleModels { get; set; }
    }
}