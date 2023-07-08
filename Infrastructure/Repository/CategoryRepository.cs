using CleanArchitectureBase.Application.CategoryCQRS.Commands.CreateCategory;
using CleanArchitectureBase.Application.CategoryCQRS.Commands.UpdateCategory;
using CleanArchitectureBase.Application.CategoryCQRS.Commands.UpdateStatus;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStatusCategory(UpdateStatusCategoryCommand command, Category category)
        {
            category.Status = command.Status;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
