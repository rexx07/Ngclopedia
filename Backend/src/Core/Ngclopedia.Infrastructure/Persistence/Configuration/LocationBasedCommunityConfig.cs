using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ngclopedia.Domain.Communities;

namespace Ngclopedia.Infrastructure.Persistence.Configuration;

public class LocationBasedCommunityConfig : IEntityTypeConfiguration<LocationBasedCommunity>
{
    public void Configure(EntityTypeBuilder<LocationBasedCommunity> builder)
    {
        builder.ToTable("Location Based Communities");
        builder.Property(lbc => lbc.Name).HasMaxLength(250);
        builder.HasOne(lbc => lbc.ApplicationUser)
            .WithMany().HasForeignKey(lbc => lbc.ApplicationUserId);
        builder.HasMany(lbc => lbc.Articles);
        builder.HasMany(lbc => lbc.Members);
        builder.HasMany(lbc => lbc.Followers);
        builder.HasMany(lbc => lbc.Excos);
        builder.HasMany(lbc => lbc.OtherLocations);
    }
}