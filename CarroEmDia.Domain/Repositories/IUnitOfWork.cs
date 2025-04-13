namespace CarroEmDia.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicles { get; }
        IUserRepository Users { get; }
        IMaintenanceRepository Maintenances { get; }
        IMaintenanceTypeRepository MaintenanceTypes { get; }

        Task<int> CommitAsync();
    }
}
