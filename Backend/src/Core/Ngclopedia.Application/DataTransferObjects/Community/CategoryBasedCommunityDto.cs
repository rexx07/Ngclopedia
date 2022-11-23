using Ngclopedia.Domain.Forums;

namespace Ngclopedia.Application.DataTransferObjects.Community;

public class CategoryBasedCommunityDto
{
    public Guid CategoryBasedCommunityId { get; init; }
    public string Name { get; init; }
    public string CategoryName { get; init; }
    public string Description { get; init; }
    public string LogoUrl { get; init; }
    public string CreatorName { get; init; }
    public Category PrimaryCategory { get; set; }
    public int TotalMembers { get; init; }
    public int TotalFollowers { get; init; }
    public int TotalArticles { get; init; }
}