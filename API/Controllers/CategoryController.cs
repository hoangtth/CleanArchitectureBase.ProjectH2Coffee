using CleanArchitectureBase.Application.CategoryCQRS.Queries.GetAllCategories;
using CleanArchitectureBase.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoryController : ApiControllerBase
    {
        /// <summary>
        /// Lấy danh sách thể loại
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCategories")]
        public async Task<IEnumerable<Category>> GetCategories() => await Mediator.Send(new GetAllCategoryQuery());
    }
}
