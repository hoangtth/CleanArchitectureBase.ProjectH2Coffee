using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.PermissionCQRS
{
    public class GetPermissionsByRoleResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
