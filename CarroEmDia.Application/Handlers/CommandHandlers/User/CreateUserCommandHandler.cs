using CarroEmDia.Domain.Entities;
using CarroEmDia.Domain.Repositories;
using CarroEmDia.Application.Shared.CQRS;
using CarroEmDia.Application.Commands.User;

namespace CarroEmDia.Application.Handlers.CommandHandlers.User
{
    public class CreateUserCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<int> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(command.Password);

            var user = new UserEntity(
                name: command.Name,
                email: command.Email,
                passwordHash: passwordHash
            );

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return user.Id;
        }
    }
}
