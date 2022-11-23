using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ngclopedia.Domain.Forums;

namespace Ngclopedia.Infrastructure.Persistence.Configuration;

public class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");
        builder.Property(c => c.Id);
        builder.HasOne(c => c.ApplicationUser).WithMany()
            .HasForeignKey(c => c.ApplicationUserId);
        builder.HasMany(c => c.Replies);
        builder.HasMany(c => c.Reactions);
    }
}