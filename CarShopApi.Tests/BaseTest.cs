using AutoMapper;
using CarShopApi.Mapping;
using MediatR;
using Moq;

namespace CarShopApi.Tests
{
    public class BaseTest
    {
        protected static IMapper Mapper { get; set; }

        protected Mock<IMediator> Mediator { get; } = new();
        
        public BaseTest()
        {
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }).CreateMapper();
        }
    }
}