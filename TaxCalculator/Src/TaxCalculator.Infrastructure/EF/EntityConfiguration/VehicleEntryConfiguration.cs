using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxCalculator.Domain.Entities;
using TaxCalculator.Infrastructure.EF.Constants;

namespace TaxCalculator.Infrastructure.EF.EntityConfiguration
{
    public class VehicleEntryConfiguration : IEntityTypeConfiguration<VehicleEntry>
    {
        public void Configure(EntityTypeBuilder<VehicleEntry> builder)
        {
            builder.ToTable(TableNames.VehicleEntries);
            builder.Property(p => p.AdditionalInfo).HasMaxLength(600).IsRequired(false);
            builder.Property(p=>p.CreateDate).IsRequired(false);
            builder.Property(p => p.UpdateDate).IsRequired(false);
            builder
                .HasOne(x => x.TollStation)
                .WithMany(x => x.VehicleEntries)
                .HasForeignKey(x => x.TollStationId);
        }
    }
}
