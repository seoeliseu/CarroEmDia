using CarroEmDia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarroEmDia.Infrastructure.Data.Context
{
    public class CarroEmDiaDbContext(DbContextOptions<CarroEmDiaDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>();
        }
    }
}
