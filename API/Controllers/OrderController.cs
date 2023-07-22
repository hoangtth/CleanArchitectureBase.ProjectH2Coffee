using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Application.OrderCQRS.Commands.CreateOrder;
using CleanArchitectureBase.Application.OrderCQRS.Queries;
using CleanArchitectureBase.Application.OrderCQRS.Queries.GetTotalOrderInMonth;
using CleanArchitectureBase.Application.OrderCQRS.Queries.GetTotalPriceOrderInMonth;
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

        [HttpGet("GetTotalPriceOrderInMonth")]
        public async Task<GetTotalPriceOrderInMonthQueryResponse> GetTotalPriceOrderInMonth() => await Mediator.Send(new GetTotalPriceOrderInMonthQuery());

        [HttpGet("GetTotalOrderInMonth")]
        public async Task<GetTotalOrderInMonthQueryResponse> GetTotalOrderInMonth() => await Mediator.Send(new GetTotalOderInMonthQuery());

    }
}
