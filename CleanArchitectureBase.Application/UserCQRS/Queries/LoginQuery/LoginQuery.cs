using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Queries.LoginQuery
{
    public class LoginQuery : IRequest<LoginQueryResponseModel>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
