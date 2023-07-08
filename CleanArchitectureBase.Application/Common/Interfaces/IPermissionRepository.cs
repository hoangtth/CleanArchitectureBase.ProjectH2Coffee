using CleanArchitectureBase.Application.PermissionCQRS;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Interfaces
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetPermissionsByRoleAsync(string roleName);
    }
}
