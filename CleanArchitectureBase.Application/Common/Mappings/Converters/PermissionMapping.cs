using AutoMapper;
using CleanArchitectureBase.Application.PermissionCQRS;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Mappings.Converters
{
    public class PermissionMapping : Profile
    {
        public PermissionMapping()
        {
            CreateMap<Permission, GetPermissionsByRoleResponseModel>();
        }
    }
}
