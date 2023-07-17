using AutoMapper;
using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using CleanArchitectureBase.Domain.Helpers;
using Domain.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Queries.GetRoleByToken
{
    public class GetRoleByTokenQueryHandler : BaseCommandHandler<GetRoleByTokenQuery, GetRoleByTokenResponseModel>
    {
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetRoleByTokenQueryHandler(IMapper mapper, IService service,IGenericRepository<Role> roleRepository,IGenericRepository<User> userRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, service)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<GetRoleByTokenResponseModel> Handle(GetRoleByTokenQuery request, CancellationToken cancellationToken)
        {
            var username = _httpContextAccessor.GetCurrentUserNameFromToken();
            if (string.IsNullOrEmpty(username))
            {
                throw new HttpStatusException(ErrorMessage.RequiredLogin, ECode.Unauthorized, (int)HttpStatusCode.Unauthorized);
            }
            var user = await _userRepository.FirstOrDefault(x => x.Username == username);
            if (user == null)
            {
                throw new HttpStatusException("User not exist", Domain.Helpers.ECode.BadRequest);
            }

            var role = await _roleRepository.FirstOrDefault(x => x.Id == user.RoleId);

            return new GetRoleByTokenResponseModel
            {
                RoleName = role.Name
            };
        }
    }
}
