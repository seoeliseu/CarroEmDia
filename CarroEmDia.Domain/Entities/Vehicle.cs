namespace CarroEmDia.Domain.Entities
{
    public class Vehicle : BaseEntity, IAggregateRoot
    {
        public int UserId { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string LicensePlate { get; private set; }

        public User User { get; private set; }
    }
}
