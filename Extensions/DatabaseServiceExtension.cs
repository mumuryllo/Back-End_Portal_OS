using Microsoft.EntityFrameworkCore;
using PortalOS.Data.Context;

namespace PortalOS.Extensions
{
    public static class DatabaseServiceExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PortalOSDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
