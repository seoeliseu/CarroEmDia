using CarroEmDia.Domain.Entities;
using CarroEmDia.Application.Shared;
using CarroEmDia.Domain.Repositories;
using CarroEmDia.Application.Commands.Vehicle;

namespace CarroEmDia.Application.Handlers.CommandHandlers
{
    public class CreateVehicleCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateVehicleCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<int> HandleAsync(CreateVehicleCommand command, CancellationToken cancellationToken = default)
        {
            var vehicle = new Vehicle(
                userId: command.UserId,
                brand: command.Brand,
                model: command.Model,
                year: command.Year,
                licensePlate: command.Plate
            );

            await _unitOfWork.Vehicles.AddAsync(vehicle);

            await _unitOfWork.CommitAsync();

            return vehicle.Id;
        }
    }
}
