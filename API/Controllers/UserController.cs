using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Application.UserCQRS.Commands.DeactiveUser;
using CleanArchitectureBase.Application.UserCQRS.Queries.GetListUsers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : ApiControllerBase
    {
        [HttpGet("GetAllUser")]
        public async Task<PaginatedList<GetAllUserResponseModel>> GetListUser([FromQuery] GetAllUserQuery query)
            => await Mediator.Send(query);

        [HttpPatch("UpdateStatusUser")]
        public async Task<bool> UpdateStatusUser(UpdateStatusUserCommand command) => await Mediator.Send(command);
    }
}
