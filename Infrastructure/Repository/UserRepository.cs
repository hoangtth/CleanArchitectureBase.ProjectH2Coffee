using CleanArchitectureBase.Application.Common.Exceptions;
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
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public UserRepository(MyDbContext context, IJwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<bool> CheckUsernameExist(string username)
        {
            var user = await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
            if(user == null)
            {
                return false;
            }
            return true;
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

        public async Task<User> GetUserDetail(int id)
        {
            var user = await _context.Users.Include(s => s.Role).Where(x => x.Id == id).SingleOrDefaultAsync();
            if(user == null)
            {
                throw new HttpStatusException("not found", CleanArchitectureBase.Domain.Helpers.ECode.BadRequest);
            }
            return user;
        }

        public async Task<string> Login(string username, string password)
        {
            var user = await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
            if(user == null)
            {
                throw new HttpStatusException("Not Exist", CleanArchitectureBase.Domain.Helpers.ECode.BadRequest);
            }
            if(user.Password != password)
            {
                throw new HttpStatusException("Wrong password", CleanArchitectureBase.Domain.Helpers.ECode.BadRequest);
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return token;

        }

        public async Task UpdateStatusUser(User user)
        {
            await _context.SaveChangesAsync();
        }
    }
}
