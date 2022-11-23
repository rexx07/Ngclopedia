using Ngclopedia.Domain.Common;

namespace Ngclopedia.Domain.Communities;

public class LocationBasedCommunity : Community
{
    public LocationBasedCommunity(
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
    public ICollection<Location> OtherLocations { get; set; }
}