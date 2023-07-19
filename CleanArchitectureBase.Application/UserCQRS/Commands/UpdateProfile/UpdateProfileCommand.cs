using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Commands.UpdateProfile
{
    public class UpdateProfileCommand : IRequest<bool>
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string? Phone { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
