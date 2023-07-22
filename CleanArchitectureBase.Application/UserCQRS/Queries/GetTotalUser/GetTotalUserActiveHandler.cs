using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Queries.GetTotalUser
{
    public class GetTotalUserActiveHandler : BaseCommandHandler<GetTotalUserActiveQuery, GetTotalUserActiveResponse>
    {
        private readonly IUserRepository _userRepository;
        public GetTotalUserActiveHandler(IMapper mapper, IService service, IUserRepository userRepository) : base(mapper, service)
        {
            _userRepository = userRepository;
        }

        public override async Task<GetTotalUserActiveResponse> Handle(GetTotalUserActiveQuery request, CancellationToken cancellationToken)
        {
            var rs = await _userRepository.GetTotalUser();
            return new GetTotalUserActiveResponse()
            {
                Total = rs
            };
        }
    }
}
