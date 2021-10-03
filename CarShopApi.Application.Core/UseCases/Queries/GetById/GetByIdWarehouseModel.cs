using CarShopApi.Domain.Models.Warehouse;
using MediatR;
using MongoDB.Bson;

namespace CarShopApi.Application.Core.UseCases.Queries.GetById
{
    public class GetByIdWarehouseModel : IRequest<Warehouse>
    {
        public string Id { get; set; }
    }
}