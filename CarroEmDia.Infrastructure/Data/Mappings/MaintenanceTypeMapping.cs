using CarroEmDia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarroEmDia.Infrastructure.Data.Mappings
{
    public class MaintenanceTypeMapping : IEntityTypeConfiguration<MaintenanceType>
    {
        public void Configure(EntityTypeBuilder<MaintenanceType> builder)
        {
            builder.ToTable("MaintenanceTypes");

            builder.HasKey(mt => mt.Id);

            builder.Property(mt => mt.Name)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(100);

            builder.Property(mt => mt.Description)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(500);

            builder.Property(mt => mt.IntervalInMonths);

            builder.Property(mt => mt.IntervalInKilometers);
        }
    }
}
