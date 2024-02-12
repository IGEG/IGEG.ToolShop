using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace IGEG.ToolShop.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
