using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.OrderCQRS.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : BaseCommandHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        public CreateOrderCommandHandler(IMapper mapper, IService service, IOrderRepository orderRepository) : base(mapper, service)
        {
            _orderRepository = orderRepository;
        }

        public override async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            await _orderRepository.AddOrder(order);

            return true;
        }
    }
}
