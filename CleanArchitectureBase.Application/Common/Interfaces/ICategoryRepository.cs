using CleanArchitectureBase.Application.CategoryCQRS.Commands.UpdateCategory;
using CleanArchitectureBase.Application.CategoryCQRS.Commands.UpdateStatus;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> UpdateStatusCategory(UpdateStatusCategoryCommand command, Category category);

        Task<bool> UpdateCategory(Category category);
    }
}
