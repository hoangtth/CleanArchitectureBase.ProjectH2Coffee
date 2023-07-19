using CleanArchitectureBase.Domain.Entities;
using CleanArchitectureBase.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Queries.GetListUsers
{
    public class GetAllUserResponseModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public int? StartDate { get; set; }

        public string? Phone { get; set; }

        public int DateOfBirth { get; set; }

        public RoleDto Role { get; set; }
    }

    public class RoleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
