using CarroEmDia.Application.Shared.CQRS;

namespace CarroEmDia.Application.Commands.User
{
    public class CreateUserCommand : ICommand<int>
    {
        public string Name { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string PasswordHash { get; init; } = null!;
    }
}
