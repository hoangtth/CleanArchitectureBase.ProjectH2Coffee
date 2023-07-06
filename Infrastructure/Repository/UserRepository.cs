using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Application.UserCQRS;
using CleanArchitectureBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<User>> GetAllUser(int offset, int limit)
        {
            var users = _context.Users.Include(x => x.Role).Where(s => s.Status == CleanArchitectureBase.Domain.Helpers.EStatus.Active);
            return new PaginatedList<User>
            {
                Total = await users.CountAsync(),
                Items = await users.Skip(offset).Take(limit).ToListAsync(),
            };
        }

        public async Task UpdateStatusUser(User user)
        {
            await _context.SaveChangesAsync();
        }
    }
}
