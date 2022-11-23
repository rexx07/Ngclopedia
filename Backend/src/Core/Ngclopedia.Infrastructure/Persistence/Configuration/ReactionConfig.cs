using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ngclopedia.Domain.Forums;

namespace Ngclopedia.Infrastructure.Persistence.Configuration;

public class ReactionConfig : IEntityTypeConfiguration<Reaction>
{
    public void Configure(EntityTypeBuilder<Reaction> builder)
    {
        builder.ToTable("Reactions");
        builder.HasOne(r => r.ApplicationUser)
            .WithMany().HasForeignKey(r => r.ApplicationUserId);
    }
}