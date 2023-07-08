using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MyDbContext _context;

        public RoleRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetRoleIdByName(string roleName)
        {
            var role = await _context.Roles.Where(x => x.Name.ToLower() == roleName.ToLower()).FirstOrDefaultAsync();
            if (role == null)
            {
                throw new HttpStatusException("Role Member Not Exist", CleanArchitectureBase.Domain.Helpers.ECode.BadRequest);
            }
            return role.Id;
        }
    }
}
