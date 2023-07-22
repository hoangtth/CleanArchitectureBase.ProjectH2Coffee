using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.OrderCQRS.Queries.GetTotalPriceOrderInMonth
{
    public class GetTotalPriceOrderInMonthQuery : IRequest<GetTotalPriceOrderInMonthQueryResponse>
    {
    }
}
