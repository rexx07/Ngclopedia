using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ngclopedia.Domain.Administrations;

namespace Ngclopedia.Infrastructure.Persistence.Configuration;

public class PoliticalOfficeHolderConfig : IEntityTypeConfiguration<PoliticalOfficeHolder>
{
    public void Configure(EntityTypeBuilder<PoliticalOfficeHolder> builder)
    {
        builder.ToTable("Political Office Holder");
        builder.HasKey(poh => poh.Id);
        builder.Property(poh => poh.LastName).HasMaxLength(250);
        builder.HasMany(poh => poh.Contacts).WithOne();
        builder.HasMany(poh => poh.PoliticalParties);
        builder.HasMany(poh => poh.PoliticalOffices);
    }
}