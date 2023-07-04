using AutoMapper;
using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.CategoryCQRS.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : BaseCommandHandler<UpdateCategoryCommand, bool>
    {
        private readonly IGenericRepository<Category> _genericRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(IMapper mapper, IService service, IGenericRepository<Category> genericRepository, ICategoryRepository categoryRepository) : base(mapper, service)
        {
            _genericRepository = genericRepository;
            _categoryRepository = categoryRepository;
        }

        public override async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _genericRepository.GetById(request.Id);
            if(category == null)
            {
                throw new HttpStatusException("Category is not exist",Domain.Helpers.ECode.BadRequest);
            }

            _mapper.Map(request, category);

            var rs = await _categoryRepository.UpdateCategory(category);

            return rs;
        }
    }
}
