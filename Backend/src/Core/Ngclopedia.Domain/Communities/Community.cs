using Ngclopedia.Domain.Common;
using Ngclopedia.Domain.Contracts;
using Ngclopedia.Domain.Forums;
using Ngclopedia.Domain.Users;

namespace Ngclopedia.Domain.Communities;

public class Community : AuditableEntity
{
    public Community(
        string name,
        string description,
        string? logoUrl,
        string applicationUserId,
        Guid contactId)
    {
        Name = name;
        Description = description;
        LogoUrl = logoUrl;
        ApplicationUserId = applicationUserId;
        ContactId = contactId;
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? LogoUrl { get; set; }
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public Guid ContactId { get; set; }
    public Contact Contact { get; set; }
    public List<ApplicationUser>? Excos { get; set; }
    public List<string>? Rules { get; set; }
    public List<string>? FAQ { get; set; }
    public List<string>? Info { get; set; }
    public ICollection<ApplicationUser>? Members { get; set; }
    public ICollection<ApplicationUser>? Followers { get; set; }
    public ICollection<Article>? Articles { get; set; }
}