using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarroEmDia.Startup
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddApplication()
                .AddInfrastructure(config)
                .AddPersistence(config);

            return services;
        }
    }
}
