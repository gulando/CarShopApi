using System.Collections.Generic;
using System.Threading.Tasks;
using CarShopApi.Application.Core.UseCases.Queries.GetAll;
using CarShopApi.Controllers;
using CarShopApi.Domain.Models.Warehouse;
using CarShopApi.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Shouldly;
using Xunit;


namespace CarShopApi.Tests.Tests
{
    public class WarehouseControllerTests : BaseTest
    {
        private readonly WarehouseController _systemUnderTest;

        public WarehouseControllerTests()
        {
            _systemUnderTest = new WarehouseController(Mapper, NullLogger<WarehouseController>.Instance, Mediator.Object);
        }
        
        [Fact]
        public async Task GetAsync_ShouldReturnOkWithViewModelAsync()
        {
            // Arrange
            var model = new List<Warehouse>();
            

            Mediator.Setup(m =>
                    m.Send(It.IsAny<GetWarehouseModel>(), default))
                .ReturnsAsync(model);

            // Act
            var response = await _systemUnderTest.GetAsync();
            var okResult = response as OkObjectResult;
            var responseViewModel = okResult?.Value as WarehouseModel;

            // Assert
            okResult.ShouldNotBeNull();
            responseViewModel.ShouldNotBeNull();
        }
    }
}