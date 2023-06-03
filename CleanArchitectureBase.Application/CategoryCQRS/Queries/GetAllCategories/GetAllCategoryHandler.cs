using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.CategoryCQRS.Queries.GetAllCategories
{
    public class GetAllCategoryHandler : BaseCommandHandler<GetAllCategoryQuery, IEnumerable<Category>>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        public GetAllCategoryHandler(IMapper mapper, IService service, IGenericRepository<Category> categoryRepository) : base(mapper, service)
        {
            _categoryRepository = categoryRepository;
        }
        public override async Task<IEnumerable<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var rs = await _categoryRepository.GetAll();
            return rs;
        }
    }
}
