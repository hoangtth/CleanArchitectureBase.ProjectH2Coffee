using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Application.ProductCQRS.Command.UpdateProduct;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<PaginatedList<Product>> GetAllProducts(int offset = 0, int limit = 10);

        Task<Product> GetById(int id);

        Task<bool> UpdateProduct(Product product);
    }
}
