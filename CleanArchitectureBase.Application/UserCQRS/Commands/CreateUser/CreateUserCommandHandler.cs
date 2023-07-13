using AutoMapper;
using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Commands.CreateUser
{
    public class CreateUserCommandHandler : BaseCommandHandler<CreateUserCommand, bool>
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository1;
        public CreateUserCommandHandler(IMapper mapper, IService service, IGenericRepository<User> userRepository, IUserRepository userRepository1, IRoleRepository roleRepository) : base(mapper, service)
        {
            _userRepository = userRepository;
            _userRepository1 = userRepository1;
            _roleRepository = roleRepository;
        }

        public override async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _userRepository1.CheckUsernameExist(request.Username);

            if (isExist)
            {
                throw new HttpStatusException("User Exist", Domain.Helpers.ECode.UserNameExist);
            }

            var user = _mapper.Map<User>(request);
            user.Status = Domain.Helpers.EStatus.Active;
            var roleId = await _roleRepository.GetRoleIdByName("Employee");
            user.RoleId = roleId;

            await _userRepository.Add(user);
            return true;
        }
    }
}
