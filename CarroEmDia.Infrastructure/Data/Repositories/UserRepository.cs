using CarroEmDia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CarroEmDia.Domain.Repositories;
using CarroEmDia.Infrastructure.Data.Context;

namespace CarroEmDia.Infrastructure.Data.Repositories
{
    public class UserRepository(CarroEmDiaDbContext context) : Repository<UserEntity>(context), IUserRepository
    {
        private readonly CarroEmDiaDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            ArgumentNullException.ThrowIfNull(email);

            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
