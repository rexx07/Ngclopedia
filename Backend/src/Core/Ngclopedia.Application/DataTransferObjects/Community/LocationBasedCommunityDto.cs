namespace Ngclopedia.Application.DataTransferObjects.Community;

public class LocationBasedCommunityDto
{
    public string Name { get; init; }
    public string CategoryName { get; init; }
    public string Description { get; init; }
    public string LogoUrl { get; init; }
    public string CreatorName { get; init; }
    public string LocationName { get; set; }
    public int TotalMembers { get; init; }
    public int TotalFollowers { get; init; }
    public int TotalArticles { get; init; }
}