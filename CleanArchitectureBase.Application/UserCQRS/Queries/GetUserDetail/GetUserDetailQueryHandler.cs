using AutoMapper;
using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : BaseCommandHandler<GetUserDetailQuery, GetUserDetailResponseModel>
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IUserRepository _userRepository1;
        public GetUserDetailQueryHandler(IMapper mapper, IService service,IGenericRepository<User> userRepository,IUserRepository userRepository1) : base(mapper, service)
        {
            _userRepository = userRepository;
            _userRepository1 = userRepository1;
        }

        public override async Task<GetUserDetailResponseModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository1.GetUserDetail(request.Id);

            return _mapper.Map<GetUserDetailResponseModel>(user);
        }
    }
}
