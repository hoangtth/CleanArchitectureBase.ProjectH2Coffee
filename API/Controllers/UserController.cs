using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Application.UserCQRS.Commands.ChangePass;
using CleanArchitectureBase.Application.UserCQRS.Commands.CreateUser;
using CleanArchitectureBase.Application.UserCQRS.Commands.DeactiveUser;
using CleanArchitectureBase.Application.UserCQRS.Commands.UpdateProfile;
using CleanArchitectureBase.Application.UserCQRS.Queries.GetListUsers;
using CleanArchitectureBase.Application.UserCQRS.Queries.GetRoleByToken;
using CleanArchitectureBase.Application.UserCQRS.Queries.GetTotalUser;
using CleanArchitectureBase.Application.UserCQRS.Queries.GetUserDetail;
using CleanArchitectureBase.Application.UserCQRS.Queries.LoginQuery;
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

        [HttpGet("{id}/GetUserDetail")]
        public async Task<GetUserDetailResponseModel> GetUserDetail(int id) => await Mediator.Send(new GetUserDetailQuery() { Id = id});

        [HttpPost("CreateUser")]
        public async Task<bool> CreateUser([FromBody] CreateUserCommand command) => await Mediator.Send(command);

        [HttpGet("Login")]
        public async Task<LoginQueryResponseModel> Login([FromQuery] LoginQuery query ) => await Mediator.Send(query);


        [HttpPost("ChangePass")]
        public async Task<bool> ChangePass([FromBody] ChangePassCommand command) => await Mediator.Send(command);

        [HttpGet("GetRoleByToken")]
        public async Task<GetRoleByTokenResponseModel> GetRoleByToken() => await Mediator.Send(new GetRoleByTokenQuery());


        [HttpPost("UpdateProfile")]
        public async Task<bool> UpdateProfile([FromBody]UpdateProfileCommand command) => await Mediator.Send(command);

        [HttpGet("GetTotalUserActive")]
        public async Task<GetTotalUserActiveResponse> GetTotalUserActive() => await Mediator.Send(new GetTotalUserActiveQuery());
    }
}
