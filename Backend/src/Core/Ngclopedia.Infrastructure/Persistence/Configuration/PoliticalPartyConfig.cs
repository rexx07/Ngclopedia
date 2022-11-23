using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ngclopedia.Domain.Administrations;

namespace Ngclopedia.Infrastructure.Persistence.Configuration;

public class PoliticalPartyConfig : IEntityTypeConfiguration<PoliticalParty>
{
    public void Configure(EntityTypeBuilder<PoliticalParty> builder)
    {
        builder.ToTable("Political Parties");
        builder.HasKey(pp => pp.Id);
        builder.Property(pp => pp.Name).HasMaxLength(250);
        builder.HasMany(pp => pp.PoliticalOffices);
        builder.HasMany(pp => pp.MergedParties);
        builder.HasMany(pp => pp.Contacts);
        builder.HasMany(pp => pp.Addresses);
    }
}