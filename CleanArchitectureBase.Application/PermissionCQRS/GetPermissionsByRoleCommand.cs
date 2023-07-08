using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.PermissionCQRS
{
    public class GetPermissionsByRoleCommand : IRequest<List<GetPermissionsByRoleResponseModel>>
    {

        [Required]
        public string RoleName { get; set; }
    }
}
