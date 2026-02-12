using PortalOS.Data.Repositories;
using PortalOS.Data.UnitOfWork;
using PortalOS.Interfaces;
using PortalOS.Interfaces.Repositories;
using PortalOS.Interfaces.Services;
using PortalOS.Middlewares;
using PortalOS.Services;

namespace PortalOS.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddScopedDependencies(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
