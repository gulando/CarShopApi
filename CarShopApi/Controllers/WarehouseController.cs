using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarShopApi.Application.Core.UseCases.Queries.GetAll;
using CarShopApi.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            _mediator = mediator;        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            var request = new GetWarehouseModel();

            var warehouses = await _mediator.Send(request, cancellationToken);

            var responseModel = _mapper.Map<List<WarehouseModel>>(warehouses);
            _logger.LogInformation($"{nameof(WarehouseController)} - {nameof(Get)}");
            
            return Ok(responseModel);
        }
    }
}