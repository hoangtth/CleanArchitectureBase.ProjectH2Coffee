using AutoMapper;
using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Commands.UpdateProfile
{
    public class UpdateProfileCommandHandler : BaseCommandHandler<UpdateProfileCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenericRepository<User> _genericRepository;
        public UpdateProfileCommandHandler(IMapper mapper, IService service,IUserRepository userRepository,IGenericRepository<User> genericRepository) : base(mapper, service)
        {
            _userRepository = userRepository;
            _genericRepository = genericRepository;
        }

        public override async Task<bool> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _genericRepository.FirstOrDefault(x => x.Username == request.Username);
            if (user == null)
            {
                throw new HttpStatusException("Not Exist User", Domain.Helpers.ECode.BadRequest);
            }

            var rs = _mapper.Map(request,user);

            await _userRepository.UpdateProfile(rs);
            return true;

        }
    }
}
