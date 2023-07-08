using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Application.PermissionCQRS;
using CleanArchitectureBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly MyDbContext _context;

        public PermissionRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Permission>> GetPermissionsByRoleAsync(string roleName)
        {
            var role = await _context.Roles.Where(x => x.Name.ToLower() == roleName.ToLower()).FirstOrDefaultAsync();
            if(role == null)
            {
                throw new HttpStatusException("Role not found",CleanArchitectureBase.Domain.Helpers.ECode.BadRequest);
            }
            var permissions = await _context.Permissions.Where(x => x.RoleId == role.Id).ToListAsync();
            
            return permissions;
        }
    }
}
