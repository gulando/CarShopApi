using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarShopApi.Application.Core.Common.IRepository;
using CarShopApi.Domain.Models.Warehouse;
using MediatR;

namespace CarShopApi.Application.Core.UseCases.Queries.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllWarehouseModel, List<Warehouse>>
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public GetAllHandler(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        
        public async Task<List<Warehouse>> Handle(GetAllWarehouseModel request, CancellationToken cancellationToken)
        {
            var warehouses = await _warehouseRepository.Get();

            if (warehouses != null && warehouses.Any())
            {
                return warehouses.ToList();
            }

            return null;
        }
    }
}