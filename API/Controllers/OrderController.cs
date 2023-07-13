using CleanArchitectureBase.Application.OrderCQRS.Commands.CreateOrder;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderController : ApiControllerBase
    {
        [HttpPost]
        public async Task<bool> AddOrder([FromBody] CreateOrderCommand command)
            => await Mediator.Send(command);
    }
}
