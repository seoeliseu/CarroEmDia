namespace CarroEmDia.Domain.Entities
{
    public class VehicleEntity(int userId, string brand, string model, int year, string licensePlate) : BaseEntity, IAggregateRoot
    {
        public int UserId { get; private set; } = userId;
        public string Brand { get; private set; } = brand;
        public string Model { get; private set; } = model;
        public int Year { get; private set; } = year;
        public string LicensePlate { get; private set; } = licensePlate;

        public UserEntity? User { get; private set; }

        private readonly List<MaintenanceEntity> _maintenances = [];
        public IReadOnlyCollection<MaintenanceEntity> Maintenances => _maintenances.AsReadOnly();
    }
}
