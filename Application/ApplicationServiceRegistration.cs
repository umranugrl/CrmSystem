using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Fluent Validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}