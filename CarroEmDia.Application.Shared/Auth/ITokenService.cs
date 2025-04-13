using CarroEmDia.Domain.Entities;

namespace CarroEmDia.Application.Shared.Auth
{
    public interface ITokenService
    {
        string GenerateToken(UserEntity user);
    }
}
