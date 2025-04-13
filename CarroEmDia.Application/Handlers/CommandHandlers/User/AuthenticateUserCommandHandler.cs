using CarroEmDia.Domain.Repositories;
using CarroEmDia.Application.Shared.CQRS;
using CarroEmDia.Application.Shared.Auth;
using CarroEmDia.Application.Commands.User;

namespace CarroEmDia.Application.Handlers.CommandHandlers.User
{
    public class AuthenticateUserCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService) : ICommandHandler<AuthenticateUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<string> HandleAsync(AuthenticateUserCommand command, CancellationToken cancellationToken = default)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(command.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(command.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Credenciais inválidas.");

            var token = _tokenService.GenerateToken(user);

            return token;
        }
    }
}
