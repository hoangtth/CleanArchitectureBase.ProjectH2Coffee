using Amazon.Runtime.Internal;
using CleanArchitectureBase.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Commands.DeactiveUser
{
    public class UpdateStatusUserCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public EStatus Status { get; set; }
    }
}
