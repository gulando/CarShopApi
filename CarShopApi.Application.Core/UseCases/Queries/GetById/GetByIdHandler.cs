using System.Threading;
using System.Threading.Tasks;
using CarShopApi.Application.Core.Common.IRepository;
using CarShopApi.Domain.Models.Warehouse;
using MediatR;
using MongoDB.Bson;

namespace CarShopApi.Application.Core.UseCases.Queries.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdWarehouseModel, Warehouse>
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public GetByIdHandler(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        
        public async Task<Warehouse> Handle(GetByIdWarehouseModel request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.Get(ObjectId.Parse(request.Id));

            return warehouse;
        }
    }
}