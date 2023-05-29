using CleanArchitectureBase.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.GetProduct.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
