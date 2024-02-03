using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IGEG.ToolShop.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
