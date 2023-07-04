using CleanArchitectureBase.Application.CategoryCQRS.Commands.UpdateCategory;
using CleanArchitectureBase.Application.CategoryCQRS.Commands.UpdateStatus;
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


        /// <summary>
        /// Cập nhật trạng thái của category
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("UpdateStatus")]
        public async Task<bool> UpdateStatus(UpdateStatusCategoryCommand command) => await Mediator.Send(command);

        /// <summary>
        /// Cập nhật thông tin category
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("UpdateCategory")]
        public async Task<bool> UpdateCategory(UpdateCategoryCommand command) => await Mediator.Send(command);
    }
}
