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

             services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMaintenanceRepository, MaintenanceRepository>();
            services.AddTransient<IMaintenanceTypeRepository, MaintenanceTypeRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
