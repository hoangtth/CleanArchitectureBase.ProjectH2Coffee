using CleanArchitectureBase.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.CategoryCQRS.Queries.GetAllCategories
{
    public class GetAllCategoryQuery : IRequest<IEnumerable<Category>>
    {
    }
}
