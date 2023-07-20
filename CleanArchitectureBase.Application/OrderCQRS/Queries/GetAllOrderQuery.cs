using CleanArchitectureBase.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.OrderCQRS.Queries
{
    public class GetAllOrderQuery : PagingQueryModel, IRequest<PaginatedList<GetAllOrdersQueryResponse>>
    {
    }
}
