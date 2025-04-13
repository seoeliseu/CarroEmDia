using CarroEmDia.Domain.Entities;
using CarroEmDia.Domain.Repositories;
using CarroEmDia.Application.Commands.Vehicle;
using CarroEmDia.Application.Shared.CQRS;

namespace CarroEmDia.Application.Handlers.CommandHandlers.Vehicle
{
    public class CreateVehicleCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateVehicleCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<int> HandleAsync(CreateVehicleCommand command, CancellationToken cancellationToken = default)
        {
            var vehicle = new VehicleEntity(
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
