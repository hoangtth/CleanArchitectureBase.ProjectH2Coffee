using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.OrderCQRS.Queries
{
    public class GetAllQueryHandler : BaseCommandHandler<GetAllOrderQuery, PaginatedList<GetAllOrdersQueryResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetAllQueryHandler(IMapper mapper, IService service, IOrderRepository orderRepository) : base(mapper, service)
        {
            _orderRepository = orderRepository;
        }

        public override async Task<PaginatedList<GetAllOrdersQueryResponse>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllOrders(request.Offset, request.Limit);

            var rs = _mapper.Map<PaginatedList<GetAllOrdersQueryResponse>>(orders);
            return rs;
        }
    }
}
