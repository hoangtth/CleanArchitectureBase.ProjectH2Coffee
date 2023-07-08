using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Queries.LoginQuery
{
    public class LoginQueryHandler : BaseCommandHandler<LoginQuery, LoginQueryResponseModel>
    {

        private readonly IUserRepository _userRepository;
        public LoginQueryHandler(IMapper mapper, IService service, IUserRepository userRepository) : base(mapper, service)
        {
            _userRepository = userRepository;
        }

        public override async Task<LoginQueryResponseModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var token = await _userRepository.Login(request.Username, request.Password);
            LoginQueryResponseModel rs = new LoginQueryResponseModel();
            rs.Token = token;
            return rs;
        }
    }
}
