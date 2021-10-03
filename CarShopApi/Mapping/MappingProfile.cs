using AutoMapper;
using CarShopApi.Domain.Models.Warehouse;
using CarShopApi.ResponseModels;

namespace CarShopApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Warehouse, WarehouseSummary>()
                .ForMember(dest => dest.Name, opt => 
                    opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Location, opt => 
                    opt.MapFrom(src => src.Cars.Location))
                .ForMember(dest => dest.Id, opt => 
                    opt.MapFrom(src => src.Id));

            CreateMap<Warehouse, WarehouseModel>()
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Cars, opt =>
                    opt.MapFrom(src => src.Cars));

            CreateMap<Car, CarModel>()
                .ForMember(dest => dest.Location, opt => 
                    opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.VehicleModels, opt => 
                    opt.MapFrom(src => src.Vehicles));
            
            CreateMap<Vehicle, VehicleModel>()
                .ForMember(dest => dest.Make, opt => 
                    opt.MapFrom(src => src.Make))
                .ForMember(dest => dest.Licensed, opt => 
                    opt.MapFrom(src => src.Licensed))
                .ForMember(dest => dest.Model, opt => 
                    opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Price, opt => 
                    opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.DateAdded, opt => 
                    opt.MapFrom(src => src.DateAdded))
                .ForMember(dest => dest.YearModel, opt => 
                    opt.MapFrom(src => src.YearModel));
        }
    }
}