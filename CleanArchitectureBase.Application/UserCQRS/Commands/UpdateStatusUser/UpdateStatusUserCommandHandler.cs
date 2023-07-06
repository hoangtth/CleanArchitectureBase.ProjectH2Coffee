using AutoMapper;
using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Commands.DeactiveUser
{
    public class UpdateStatusUserCommandHandler : BaseCommandHandler<UpdateStatusUserCommand, bool>
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IUserRepository _userRepository1;
        public UpdateStatusUserCommandHandler(IMapper mapper, IService service,IGenericRepository<User> userRepository,IUserRepository userRepository1) : base(mapper, service)
        {
            _userRepository = userRepository;
            _userRepository1 = userRepository1;
        }

        public override async Task<bool> Handle(UpdateStatusUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user == null)
            {
                throw new HttpStatusException("Not Found",Domain.Helpers.ECode.BadRequest);
            }

            user.Status = request.Status;

            await _userRepository1.UpdateStatusUser(user);

            return true;
        }
    }
}
