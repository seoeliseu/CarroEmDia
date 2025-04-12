using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CarroEmDia.Infrastructure.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace CarroEmDia.Startup
{
    public static class PersistenceServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CarroEmDiaDbContext>(options =>
                    options.UseSqlServer(
                        config.GetConnectionString("Default"),
                        sqlServerOptions => sqlServerOptions.MigrationsAssembly("SeuProjeto.Migrations")
                    ));

            return services;
        }
    }
}
