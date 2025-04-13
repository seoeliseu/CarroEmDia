using CarroEmDia.Infrastructure.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarroEmDia.Application.Shared.Common.Interfaces;
using CarroEmDia.Application.Shared.Auth;

namespace CarroEmDia.Startup
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddMemoryCache();
            services.AddHttpClient();

            services.AddHttpContextAccessor();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICurrentUser, CurrentUser>();

            return services;
        }
    }
}
