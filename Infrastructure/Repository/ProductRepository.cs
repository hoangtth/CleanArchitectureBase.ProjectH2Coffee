using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Include(c => c.Category).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<PaginatedList<Product>> GetAllProducts(int offset, int limit)
        {
            var result = _context.Products;
            return new PaginatedList<Product>
            {
                Total = await result.CountAsync(),
                Items = await result.Skip(offset).Take(limit).ToListAsync()
            };
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
