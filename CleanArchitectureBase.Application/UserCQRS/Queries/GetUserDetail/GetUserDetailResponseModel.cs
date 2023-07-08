using CleanArchitectureBase.Application.UserCQRS.Queries.GetListUsers;
using CleanArchitectureBase.Domain.Entities;
using CleanArchitectureBase.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Queries.GetUserDetail
{
    public class GetUserDetailResponseModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public EStatus Status { get; set; }

        public RoleDto Role { get; set; }
    }
}
