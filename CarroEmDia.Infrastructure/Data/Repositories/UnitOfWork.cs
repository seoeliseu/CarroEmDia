using CarroEmDia.Domain.Entities;
using CarroEmDia.Domain.Repositories;
using CarroEmDia.Infrastructure.Data.Context;

namespace CarroEmDia.Infrastructure.Data.Repositories
{
    public class UnitOfWork(CarroEmDiaDbContext context,
                            IVehicleRepository vehicleRepository,
                            IUserRepository userRepository,
                            IMaintenanceRepository maintenanceRepository,
                            IMaintenanceTypeRepository maintenanceTypeRepository) : IUnitOfWork
    {
        private readonly CarroEmDiaDbContext _context = context;

        public IVehicleRepository Vehicles { get; } = vehicleRepository;
        public IUserRepository Users { get; } = userRepository;
        public IMaintenanceRepository Maintenances { get; } = maintenanceRepository;
        public IMaintenanceTypeRepository MaintenanceTypes { get; } = maintenanceTypeRepository;

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
