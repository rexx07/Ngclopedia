using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ngclopedia.Domain.Common;

namespace Ngclopedia.Infrastructure.Persistence.Configuration;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).HasMaxLength(250);
    }
}