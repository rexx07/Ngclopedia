using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ngclopedia.Domain.Administrations;

namespace Ngclopedia.Infrastructure.Persistence.Configuration;

public class PoliticalOfficeConfig : IEntityTypeConfiguration<PoliticalOffice>
{
    public void Configure(EntityTypeBuilder<PoliticalOffice> builder)
    {
        builder.ToTable("Political Offices");
        builder.HasKey(po => po.Id);
        builder.Property(po => po.Name).HasMaxLength(250);
        builder.HasMany(po => po.Contacts).WithOne();
        builder.HasMany(po => po.Addresses).WithOne();
        builder.HasMany(po => po.PoliticalOfficeHolders).WithOne();
    }
}