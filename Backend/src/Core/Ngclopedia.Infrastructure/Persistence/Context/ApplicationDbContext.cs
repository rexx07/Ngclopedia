using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Interfaces.Common;
using Ngclopedia.Domain.Administrations;
using Ngclopedia.Domain.Auth;
using Ngclopedia.Domain.Common;
using Ngclopedia.Domain.Communities;
using Ngclopedia.Domain.Forums;
using Ngclopedia.Domain.Users;
using Ngclopedia.Infrastructure.Persistence.Configuration;

namespace Ngclopedia.Infrastructure.Persistence.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
    IdentityUserRole<string>, IdentityUserLogin<string>, ApplicationRoleClaim, IdentityUserToken<string>>
{
    protected readonly ICurrentUser _currentUser;
    private readonly ISerializerService _serializer;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUser currentUser,
        ISerializerService serializer) : base(options)
    {
        _currentUser = currentUser;
        _serializer = serializer;
    }

    public DbSet<Address>? Addresses { get; set; }
    public DbSet<Article>? Articles { get; set; }
    public DbSet<CategoryBasedCommunity>? CategoryBasedCommunities { get; set; }
    public DbSet<Comment>? Comments { get; set; }
    public DbSet<Contact>? Contacts { get; set; }
    public DbSet<LocationBasedCommunity>? LocationBasedCommunities { get; set; }
    public DbSet<Location>? Locations { get; set; }
    public DbSet<PoliticalOffice>? PoliticalOffices { get; set; }
    public DbSet<PoliticalOfficeHolder>? PoliticalOfficeHolders { get; set; }
    public DbSet<PoliticalParty>? PoliticalParties { get; set; }
    public DbSet<Reaction>? Reactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new IdentityUserTokenConfig());
        modelBuilder.ApplyConfiguration(new IdentityUserTokenConfig());
        modelBuilder.ApplyConfiguration(new IdentityUserClaimConfig());
        modelBuilder.ApplyConfiguration(new IdentityUserRoleConfig());
        modelBuilder.ApplyConfiguration(new ApplicationRoleClaimConfig());
        modelBuilder.ApplyConfiguration(new ApplicationRoleConfig());
        modelBuilder.ApplyConfiguration(new ApplicationUserConfig());
        modelBuilder.ApplyConfiguration(new AddressConfig());
        modelBuilder.ApplyConfiguration(new ContactConfig());
        modelBuilder.ApplyConfiguration(new CommentConfig());
        modelBuilder.ApplyConfiguration(new PoliticalOfficeConfig());
        modelBuilder.ApplyConfiguration(new PoliticalOfficeHolderConfig());
        modelBuilder.ApplyConfiguration(new PoliticalPartyConfig());
        modelBuilder.ApplyConfiguration(new ArticleConfig());
        modelBuilder.ApplyConfiguration(new CategoryBasedCommunityConfig());
        modelBuilder.ApplyConfiguration(new LocationBasedCommunityConfig());
        modelBuilder.ApplyConfiguration(new LocationConfig());
        modelBuilder.ApplyConfiguration(new ReactionConfig());
    }
}