using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Application.OrderCQRS.Commands.CreateOrder;
using CleanArchitectureBase.Application.OrderCQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderController : ApiControllerBase
    {
        [HttpPost]
        public async Task<bool> AddOrder([FromBody] CreateOrderCommand command)
            => await Mediator.Send(command);

        [HttpGet("GetAllOrders")]
        public async Task<PaginatedList<GetAllOrdersQueryResponse>> GetAllOrders([FromQuery]GetAllOrderQuery query) =>
            await Mediator.Send(query);
    }
}
