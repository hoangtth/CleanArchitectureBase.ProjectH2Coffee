using CleanArchitectureBase.Application.Common.Interfaces;
using Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IProductRepository, ProductRepository>(); 
            services.AddTransient<ICategoryRepository, CategoryRepository>(); 
            services.AddTransient<IUserRepository, UserRepository>(); 
            services.AddTransient<IRoleRepository, RoleRepository>(); 
            services.AddTransient<IPermissionRepository, PermissionRepository>(); 
            //var connectionString = configuration.GetConnectionString("SqlConnection");
            services.AddDbContext<MyDbContext>();
        }
    }
}
