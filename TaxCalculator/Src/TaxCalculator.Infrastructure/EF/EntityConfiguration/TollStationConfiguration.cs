using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxCalculator.Domain.Entities;
using TaxCalculator.Infrastructure.EF.Constants;

namespace TaxCalculator.Infrastructure.EF.EntityConfiguration
{
    public class TollStationConfiguration : IEntityTypeConfiguration<TollStation>
    {
        public void Configure(EntityTypeBuilder<TollStation> builder)
        {
            builder.ToTable(TableNames.TollStations);
            builder.Property(p => p.City).HasMaxLength(200).IsRequired(false);
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired(false);
            builder.Property(p => p.CreateDate).IsRequired(false);
            builder.Property(p => p.UpdateDate).IsRequired(false);
            builder
                .HasMany(x => x.VehicleEntries)
                .WithOne(x => x.TollStation)
                .HasForeignKey(x => x.TollStationId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
