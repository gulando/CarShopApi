using System.Collections.Generic;
using CarShopApi.Domain.Models.Warehouse;
using MediatR;

namespace CarShopApi.Application.Core.UseCases.Queries.GetAll
{
    public class GetAllWarehouseModel : IRequest<List<Warehouse>>
    {
    }
}