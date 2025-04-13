using CarroEmDia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarroEmDia.Infrastructure.Data.Context
{
    public class CarroEmDiaDbContext(DbContextOptions<CarroEmDiaDbContext> options) : DbContext(options)
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarroEmDiaDbContext).Assembly);
        }
    }
}
