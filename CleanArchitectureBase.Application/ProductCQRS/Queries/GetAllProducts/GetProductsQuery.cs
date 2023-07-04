using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.ProductCQRS.Queries.GetAllProducts
{
    public class GetProductsQuery : PagingQueryModel , IRequest<PaginatedList<GetAllProductResponse>>
    {
    }
}
