
using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Application.ProductCQRS.Command.CreateProduct;
using CleanArchitectureBase.Application.ProductCQRS.Command.DeleteProduct;
using CleanArchitectureBase.Application.ProductCQRS.Command.UpdateProduct;
using CleanArchitectureBase.Application.ProductCQRS.Queries.GetAllProducts;
using CleanArchitectureBase.Application.ProductCQRS.Queries.GetProductById;
using CleanArchitectureBase.Application.ProductCQRS.Queries.GetTotalProductActive;
using CleanArchitectureBase.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : ApiControllerBase
    {

        /// <summary>
        /// Lấy danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProducts")]
        public async Task<PaginatedList<GetAllProductResponse>> GetProductsAsync([FromQuery]GetProductsQuery query) => await Mediator.Send(query);

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


        /// <summary>
        /// Xóa product từ Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<bool> DeleteProductAsync(int id) => await Mediator.Send(new DeleteProductById()
        {
            Id = id
        });



        /// <summary>
        /// Cập nhật sản phẩm
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("UpdateProduct")]
        public async Task<bool> UpdateProduct(UpdateProductCommand command) => await Mediator.Send(command);

        /// <summary>
        /// Tạo sản phẩm
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("CreateProduct")]
        public async Task<bool> CreateProduct([FromBody] CreateProductCommand command) => await Mediator.Send(command);

        [HttpGet("GetTotalProductActive")]
        public async Task<GetTotalProductActiveResponseModel> GetTotalProductActive() => await Mediator.Send(new GetTotalProductActiveQuery());
    }
}
