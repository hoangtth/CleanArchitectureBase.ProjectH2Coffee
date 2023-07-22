using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Queries.GetTotalUser
{
    public class GetTotalUserActiveQuery : IRequest<GetTotalUserActiveResponse>
    {
    }
}
