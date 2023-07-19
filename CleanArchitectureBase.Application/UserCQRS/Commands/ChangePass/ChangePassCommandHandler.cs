using AutoMapper;
using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Commands.ChangePass
{
    public class ChangePassCommandHandler : BaseCommandHandler<ChangePassCommand, bool>
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IUserRepository _userRepository1;
        public ChangePassCommandHandler(IMapper mapper, IService service,IGenericRepository<User> userRepository, IUserRepository userRepository1) : base(mapper, service)
        {
            _userRepository = userRepository;
            _userRepository1 = userRepository1;
        }

        public override async Task<bool> Handle(ChangePassCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FirstOrDefault(x => x.Username == request.Username);
            if (user == null)
            {
                throw new HttpStatusException("User is not exist", Domain.Helpers.ECode.BadRequest, (int)HttpStatusCode.BadRequest);
            }
            if(user.Password == request.OldPass)
            {
                user.Password = request.NewPass;
                await _userRepository1.ChangePass(user);
                return true;
            }

            throw new HttpStatusException("The old password you enter is wrong!", Domain.Helpers.ECode.BadRequest);
            
        }
    }
}
