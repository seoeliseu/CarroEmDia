namespace CarroEmDia.Domain.Entities
{
    public class User(string name, string email) : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;


        private readonly List<Vehicle> _vehicles = [];
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles.AsReadOnly();

        public void AddVehicle(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);
            _vehicles.Add(vehicle);
        }
    }
}
