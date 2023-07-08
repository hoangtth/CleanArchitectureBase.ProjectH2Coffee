using CleanArchitectureBase.Application.PermissionCQRS;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PermissionController : ApiControllerBase
    {
        [HttpGet("GetPermissionsByRole")]
        public async Task<List<GetPermissionsByRoleResponseModel>> GetPermissionsByRole([FromQuery] GetPermissionsByRoleCommand query)
            => await Mediator.Send(query);
    }
}
