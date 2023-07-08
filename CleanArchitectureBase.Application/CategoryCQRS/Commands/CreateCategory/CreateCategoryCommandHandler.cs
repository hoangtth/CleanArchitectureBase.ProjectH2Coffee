using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.CategoryCQRS.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : BaseCommandHandler<CreateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryCommandHandler(IMapper mapper, IService service, ICategoryRepository categoryRepository) : base(mapper, service)
        {
            _categoryRepository = categoryRepository;
        }

        public override async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            category.Status = Domain.Helpers.EStatus.Active;
            var rs = await _categoryRepository.CreateCategory(category);
            return rs;
        }
    }
}
