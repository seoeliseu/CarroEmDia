using CarroEmDia.Application.Shared.CQRS;

namespace CarroEmDia.Application.Commands.User
{
    public class AuthenticateUserCommand : ICommand<string>
    {
        public required string Email { get; init; }
        public required string Password { get; init; }
    }
}
