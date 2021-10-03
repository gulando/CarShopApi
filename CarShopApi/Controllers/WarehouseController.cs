using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarShopApi.Application.Core.UseCases.Queries.GetAll;
using CarShopApi.Application.Core.UseCases.Queries.GetById;
using CarShopApi.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace CarShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly ILogger<WarehouseController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public WarehouseController(IMapper mapper, ILogger<WarehouseController> logger, IMediator mediator)
        {
            _mapper = mapper;
            _logger = logger;
            _mediator = mediator;        
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var request = new GetAllWarehouseModel();

            var warehouses = await _mediator.Send(request, cancellationToken);

            var responseModel = _mapper.Map<List<WarehouseSummary>>(warehouses);
            _logger.LogInformation($"{nameof(WarehouseController)} - {nameof(GetAllAsync)}");
            
            return Ok(responseModel);
        }
        
        [HttpGet("/id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] string id, CancellationToken cancellationToken = default)
        {
            var request = new GetByIdWarehouseModel {Id = id};

            var warehouses = await _mediator.Send(request, cancellationToken);

            var responseModel = _mapper.Map<WarehouseModel>(warehouses);
            
            _logger.LogInformation($"{nameof(WarehouseController)} - {nameof(GetByIdAsync)}");
            
            return Ok(responseModel);
        }
    }
}