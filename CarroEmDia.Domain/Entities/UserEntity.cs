namespace CarroEmDia.Domain.Entities
{
    public class UserEntity(string name, string email, string passwordHash) : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public string PasswordHash { get; private set; } = passwordHash;

        private readonly List<VehicleEntity> _vehicles = [];
        public IReadOnlyCollection<VehicleEntity> Vehicles => _vehicles.AsReadOnly();

        public void AddVehicle(VehicleEntity vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);
            _vehicles.Add(vehicle);
        }

        public void UpdatePassword(string newPasswordHash)
        {
            ArgumentNullException.ThrowIfNull(newPasswordHash);
            PasswordHash = newPasswordHash;
        }
    }
}
