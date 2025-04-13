using CarroEmDia.Domain.Repositories;
using CarroEmDia.Application.Commands.User;
using CarroEmDia.Application.Shared.CQRS;

namespace CarroEmDia.Application.Handlers.CommandHandlers.User
{
    internal class UpdateUserPasswordCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserPasswordCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> HandleAsync(UpdateUserPasswordCommand command, CancellationToken cancellationToken = default)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(command.UserId);

            if (user == null)
                return false;

            user.UpdatePassword(command.NewPasswordHash);

            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
