using CarroEmDia.Application.Commands.User;
using CarroEmDia.Domain.Repositories;
using CarroEmDia.Domain.Entities;
using CarroEmDia.Application.Shared.CQRS;


namespace CarroEmDia.Application.Handlers.CommandHandlers.User
{
    public class CreateUserCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<int> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
        {
            var user = new UserEntity(
                name: command.Name,
                email: command.Email,
                passwordHash: command.PasswordHash
            );

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return user.Id;
        }
    }
}
