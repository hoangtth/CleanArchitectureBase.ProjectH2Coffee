using AutoMapper;
using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Application.UserCQRS.Queries.GetListUsers;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping() {
            CreateMap<User, GetAllUserResponseModel>();
            CreateMap<PaginatedList<User>, PaginatedList<GetAllUserResponseModel>>();
            CreateMap<Role, RoleDto>();
        }
    }
}
