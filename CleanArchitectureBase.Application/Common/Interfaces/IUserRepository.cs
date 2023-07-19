using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Application.UserCQRS;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<PaginatedList<User>> GetAllUser(int offset,int limit);

        Task UpdateStatusUser(User user);

        Task<User> GetUserDetail(int id);

        Task<bool> CheckUsernameExist(string username);

        Task<string> Login(string username,string password);

        Task<bool> ChangePass(User user);

        Task<bool> UpdateProfile(User user);
    }
}
