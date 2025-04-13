using CarroEmDia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarroEmDia.Infrastructure.Data.Mappings
{
    public class VehicleMapping : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Brand)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.Model)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.Year)
                .IsRequired();

            builder.Property(v => v.LicensePlate)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(v => v.User)
                   .WithMany(u => u.Vehicles)
                   .HasForeignKey(v => v.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
