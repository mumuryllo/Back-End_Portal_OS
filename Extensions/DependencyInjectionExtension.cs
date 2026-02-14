using FluentValidation;
using PortalOS.Data.Mappings.AutoMapping;
using PortalOS.Data.Repositories;
using PortalOS.Data.UnitOfWork;
using PortalOS.Interfaces;
using PortalOS.Interfaces.Repositories;
using PortalOS.Interfaces.Services;
using PortalOS.Mappings;
using PortalOS.Middlewares;
using PortalOS.Services;
using PortalOS.Services.Interfaces;
using PortalOS.Validators;

namespace PortalOS.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddScopedDependencies(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            //Fornecedor
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IFornecedorService, FornecedorService>();

            return services;
        }

        public static IServiceCollection AddMappingDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(FornecedorProfile));
            return services;
        }
        public static IServiceCollection AddValidatorDependencies(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<FornecedorRequestValidator>();
            return services;
        }
    }
}
