using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ngclopedia.Domain.Common;

namespace Ngclopedia.Infrastructure.Persistence.Configuration;

public class LocationConfig : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Name).HasMaxLength(250);
    }
}