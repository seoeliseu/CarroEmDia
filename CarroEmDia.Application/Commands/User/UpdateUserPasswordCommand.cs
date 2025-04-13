using CarroEmDia.Application.Shared.CQRS;

namespace CarroEmDia.Application.Commands.User
{
    public class UpdateUserPasswordCommand : ICommand<bool>
    {
        public int UserId { get; init; }
        public string NewPasswordHash { get; init; } = null!;
    }
}
