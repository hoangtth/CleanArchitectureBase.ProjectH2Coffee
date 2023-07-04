using AutoMapper;
using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.CategoryCQRS.Commands.UpdateStatus
{
    public class UpdateStatusCategoryHandler : BaseCommandHandler<UpdateStatusCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGenericRepository<Category> _genericRepository;

        public UpdateStatusCategoryHandler(IMapper mapper, IService service, ICategoryRepository categoryRepository, IGenericRepository<Category> genericRepository) : base(mapper, service)
        {
            _categoryRepository = categoryRepository;
            _genericRepository = genericRepository;
        }

        public override async Task<bool> Handle(UpdateStatusCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _genericRepository.GetById(request.Id);
            if(category == null)
            {
                throw new HttpStatusException("Category is not exist",Domain.Helpers.ECode.BadRequest);
            }

            var rs = await _categoryRepository.UpdateStatusCategory(request, category);

            return rs;
        }
    }
}
