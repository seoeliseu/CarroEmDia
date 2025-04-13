using CarroEmDia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarroEmDia.Infrastructure.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(u => u.Vehicles)
                   .WithOne(v => v.User)             
                   .HasForeignKey(v => v.UserId)    
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
