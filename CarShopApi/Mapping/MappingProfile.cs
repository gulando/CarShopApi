using AutoMapper;
using CarShopApi.Domain.Models.Warehouse;
using CarShopApi.ResponseModels;

namespace CarShopApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Warehouse, WarehouseModel>()
                .ForMember(dest => dest.Name, opt => 
                    opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Location, opt => 
                    opt.MapFrom(src => src.Cars.Location));
        }
    }
}