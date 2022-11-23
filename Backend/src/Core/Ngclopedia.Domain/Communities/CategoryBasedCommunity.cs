using Ngclopedia.Domain.Forums;

namespace Ngclopedia.Domain.Communities;

public class CategoryBasedCommunity : Community
{
    public CategoryBasedCommunity(
        string name,
        string description,
        string? logoUrl,
        string applicationUserId,
        Guid contactId): base(name, description, logoUrl, applicationUserId, contactId)
    {
        Name = name;
        Description = description;
        LogoUrl = logoUrl;
        ApplicationUserId = applicationUserId;
        ContactId = contactId;
    }
    public List<Category> Categories { get; set; }
}