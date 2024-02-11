using IGEG.ToolShop.Persistance.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IGEG.ToolShop.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("AbbDBcontext")));

            return services;
        }
    }
}
