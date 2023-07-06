using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Queries.GetListUsers
{
    public class GetAllUserQueryHandler : BaseCommandHandler<GetAllUserQuery, PaginatedList<GetAllUserResponseModel>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUserQueryHandler(IMapper mapper, IService service, IUserRepository userRepository) : base(mapper, service)
        {
            _userRepository = userRepository;
        }

        public override async Task<PaginatedList<GetAllUserResponseModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUser(request.Offset, request.Limit);

            return _mapper.Map<PaginatedList<GetAllUserResponseModel>>(users);
        }
    }
}
