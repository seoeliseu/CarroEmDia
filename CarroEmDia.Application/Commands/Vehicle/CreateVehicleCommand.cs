using CarroEmDia.Application.Shared;

namespace CarroEmDia.Application.Commands.Vehicle
{
    public class CreateVehicleCommand : ICommand<int>
    {
        public string Plate { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int UserId { get; set; }
    }
}
