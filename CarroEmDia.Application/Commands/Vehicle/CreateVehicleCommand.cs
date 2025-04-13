using CarroEmDia.Application.Shared.CQRS;

namespace CarroEmDia.Application.Commands.Vehicle
{
    public class CreateVehicleCommand : ICommand<int>
    {
        public string Plate { get; init; } = null!;
        public string Brand { get; init; } = null!;
        public string Model { get; init; } = null!;
        public int Year { get; init; }
        public int UserId { get; init; }
    }
}
