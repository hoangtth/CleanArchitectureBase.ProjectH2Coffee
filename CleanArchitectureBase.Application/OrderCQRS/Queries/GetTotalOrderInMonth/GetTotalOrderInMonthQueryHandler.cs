using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.OrderCQRS.Queries.GetTotalOrderInMonth
{
    public class GetTotalOrderInMonthQueryHandler : BaseCommandHandler<GetTotalOderInMonthQuery, GetTotalOrderInMonthQueryResponse>
    {
        private readonly IOrderRepository _orderRepository;
        public GetTotalOrderInMonthQueryHandler(IMapper mapper, IService service, IOrderRepository orderRepository) : base(mapper, service)
        {
            _orderRepository = orderRepository;
        }

        public override async Task<GetTotalOrderInMonthQueryResponse> Handle(GetTotalOderInMonthQuery request, CancellationToken cancellationToken)
        {
            var total = await _orderRepository.GetTotalOrderInMonth();
           
            return new GetTotalOrderInMonthQueryResponse()
            {
                Total = total
            };
        }
    }
}
