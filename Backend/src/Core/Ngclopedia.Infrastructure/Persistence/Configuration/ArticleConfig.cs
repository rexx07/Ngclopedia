using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ngclopedia.Domain.Forums;

namespace Ngclopedia.Infrastructure.Persistence.Configuration;

public class ArticleConfig : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles");
        builder.Property(a => a.Title).HasMaxLength(250);
        builder.HasOne(a => a.ApplicationUser)
            .WithMany().HasForeignKey(a => a.ApplicationUserId);
        builder.HasMany(a => a.Reactions).WithOne();
        builder.HasMany(a => a.Comments).WithOne();
    }
}