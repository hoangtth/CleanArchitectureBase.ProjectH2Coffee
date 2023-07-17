using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Queries.GetRoleByToken
{
    public class GetRoleByTokenQuery : IRequest<GetRoleByTokenResponseModel>
    {
    }
}
