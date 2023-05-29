
using CleanArchitectureBase.Application.ProductCQRS.Queries.GetAllProducts;
using CleanArchitectureBase.Application.ProductCQRS.Queries.GetProductById;
using CleanArchitectureBase.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class ProductController : ApiControllerBase
    {

        /// <summary>
        /// Lấy danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProducts")]
        public async Task<IEnumerable<Product>> GetProductsAsync() => await Mediator.Send(new GetProductsQuery());

        /// <summary>
        /// Lấy product theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Product> GetProductByIdAsync(int id) => await Mediator.Send(new GetProductByIdQuery()
        {
            Id = id
        });
    }
}
