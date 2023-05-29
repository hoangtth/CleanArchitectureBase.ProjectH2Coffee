using CleanArchitectureBase.Application.Common.Behaviours;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Application.Common.Mappings.Converters;
using CleanArchitectureBase.Application.Common.Middleware;
using CleanArchitectureBase.Application.Common.Services;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddAutoMapper(configAction: cfg =>
            {
                cfg.CreateMap<DateTime?, int?>().ConvertUsing(new DateTimeTypeConverter());
                cfg.CreateMap<int?, DateTime?>().ConvertUsing(new DateTimeTypeConverter());
                cfg.CreateMap<DateTime, int>().ConvertUsing(new DateTimeTypeConverter());
                cfg.CreateMap<int, DateTime>().ConvertUsing(new DateTimeTypeConverter());
                cfg.CreateMap<DateOnly?, int?>().ConvertUsing(new DateTimeTypeConverter());
            }, Assembly.GetExecutingAssembly());
            services.AddFluentValidation(fv =>
            {
                fv.AutomaticValidationEnabled = true;
                fv.DisableDataAnnotationsValidation = true;
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped<IService, Service>();
            return services;
        }

        public static IApplicationBuilder AddApplication(this IApplicationBuilder app)
        {
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            return app;
        }
    }
}
