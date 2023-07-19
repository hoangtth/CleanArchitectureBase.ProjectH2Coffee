using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Commands.ChangePass
{
    public class ChangePassCommand : IRequest<bool>
    {
        public string Username { get; set; }

        public string OldPass { get; set; }
        public string NewPass { get; set; }
    }
}
