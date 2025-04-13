using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CarroEmDia.Infrastructure.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using CarroEmDia.Domain.Repositories;
using CarroEmDia.Infrastructure.Data.Repositories;

namespace CarroEmDia.Startup
{
    public static class PersistenceServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CarroEmDiaDbContext>(options =>
            options.UseSqlite(
                config.GetConnectionString("Default"),
                sqliteOptions => sqliteOptions.MigrationsAssembly("CarroEmDia.Infrastructure")
            ));

             services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
            services.AddScoped<IMaintenanceTypeRepository, MaintenanceTypeRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
