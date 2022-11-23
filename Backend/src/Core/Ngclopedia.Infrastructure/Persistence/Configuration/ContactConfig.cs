using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ngclopedia.Domain.Common;

namespace Ngclopedia.Infrastructure.Persistence.Configuration;

public class ContactConfig : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(250);
    }
}