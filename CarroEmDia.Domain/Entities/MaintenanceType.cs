namespace CarroEmDia.Domain.Entities
{
    public class MaintenanceType(string name, string description) : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; } = name;
        public string Description { get; private set; } = description;

        public int? IntervalInMonths { get; private set; }
        public int? IntervalInKilometers { get; private set; }

        public MaintenanceType(string name, string description, int? intervalInMonths, int? intervalInKilometers) : this(name, description)
        {
            IntervalInMonths = intervalInMonths;
            IntervalInKilometers = intervalInKilometers;
        }
    }
}
