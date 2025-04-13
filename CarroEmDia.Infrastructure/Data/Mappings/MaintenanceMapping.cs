using CarroEmDia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarroEmDia.Infrastructure.Data.Mappings
{
    public class MaintenanceMapping : IEntityTypeConfiguration<MaintenanceEntity>
    {
        public void Configure(EntityTypeBuilder<MaintenanceEntity> builder)
        {
            builder.ToTable("Maintenances");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.MaintenanceTypeId)
                   .IsUnicode(false)
                   .IsRequired();

            builder.Property(m => m.Description).IsRequired().HasMaxLength(500);

            builder.Property(m => m.MaintenanceDate).IsRequired();

            builder.Property(m => m.MileageAtMaintenance).IsRequired();

            builder.Property(m => m.Cost)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(m => m.NextExpectedMaintenanceMileage)
                .IsRequired(false);

            builder.Property(m => m.NextExpectedMaintenanceDate)
                .IsRequired(false);

            builder.Property(m => m.IsCompleted)
                .IsRequired();

            builder.HasOne(m => m.Vehicle)
                .WithMany(v => v.Maintenances)
                .HasForeignKey(m => m.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.MaintenanceType)
                   .WithMany()
                   .HasForeignKey(m => m.MaintenanceTypeId);
        }
    }
}
