using CarroEmDia.Domain.Entities;

namespace CarroEmDia.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity?> GetByEmailAsync(string email);
    }
}
