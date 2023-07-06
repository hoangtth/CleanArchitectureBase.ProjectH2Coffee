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
    }
}
