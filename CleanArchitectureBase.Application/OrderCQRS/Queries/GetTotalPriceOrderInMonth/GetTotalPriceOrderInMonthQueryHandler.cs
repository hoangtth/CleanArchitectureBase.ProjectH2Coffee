using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.OrderCQRS.Queries.GetTotalPriceOrderInMonth
{
    public class GetTotalPriceOrderInMonthQueryHandler : BaseCommandHandler<GetTotalPriceOrderInMonthQuery, GetTotalPriceOrderInMonthQueryResponse>
    {
        private readonly IOrderRepository _orderRepository;
        public GetTotalPriceOrderInMonthQueryHandler(IMapper mapper, IService service, IOrderRepository orderRepository) : base(mapper, service)
        {
            _orderRepository = orderRepository;
        }

        public override async Task<GetTotalPriceOrderInMonthQueryResponse> Handle(GetTotalPriceOrderInMonthQuery request, CancellationToken cancellationToken)
        {
            var rs = await _orderRepository.GetTotalPriceInMonth();
            return new GetTotalPriceOrderInMonthQueryResponse
            {
                TotalPriceOrderInMonth = rs
            };
        }
    }
}
