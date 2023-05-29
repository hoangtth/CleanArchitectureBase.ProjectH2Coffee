using CleanArchitectureBase.Application.GetProduct.Queries;
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
        [HttpGet("GetProduct")]
        public async Task<IEnumerable<Product>> GetProductsAsync() => await Mediator.Send(new GetProductsQuery());
    }
}
