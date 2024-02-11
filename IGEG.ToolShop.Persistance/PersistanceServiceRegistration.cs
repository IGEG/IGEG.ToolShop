using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Persistance.DataContext;
using IGEG.ToolShop.Persistance.Repositories;
using IGEG.ToolShop.Persistance.Repositories.Common;
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

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
