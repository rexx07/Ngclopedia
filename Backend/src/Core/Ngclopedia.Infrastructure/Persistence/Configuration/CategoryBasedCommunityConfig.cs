using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ngclopedia.Domain.Communities;

namespace Ngclopedia.Infrastructure.Persistence.Configuration;

public class CategoryBasedCommunityConfig
    
    
    
    : IEntityTypeConfiguration<CategoryBasedCommunity>
{
    public void Configure(EntityTypeBuilder<CategoryBasedCommunity> builder)
    {
        builder.ToTable("Category Based Communities");
        builder.Property(cbc => cbc.Name).HasMaxLength(250);
        builder.HasOne(cbc => cbc.ApplicationUser)
            .WithMany().HasForeignKey(cbc => cbc.ApplicationUserId);
        builder.HasMany(cbc => cbc.Articles);
        builder.HasMany(cbc => cbc.Members);
        builder.HasMany(cbc => cbc.Followers);
        builder.HasMany(cbc => cbc.Excos);
    }
}