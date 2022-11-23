using Ngclopedia.Application.DataTransferObjects.Common;
using Ngclopedia.Application.DataTransferObjects.Forum;
using Ngclopedia.Application.DataTransferObjects.Users;

namespace Ngclopedia.Application.DataTransferObjects.Community;

public class LocationBasedCommunityWithDetailsDto
{
    public string Name { get; init; }
    public string Description { get; init; }
    public string LogoUrl { get; init; }
    public string CreatorName { get; init; }
    public ContactDto Contact { get; init; }
    public List<UserDto> Excos { get; init; }
    public List<string> Rules { get; init; }
    public List<string> FAQ { get; init; }
    public List<string> Info { get; init; }
    public LocationDto PrimaryLocation { get; init; }
    public LocationDto[]? Locations { get; init; }
    public ICollection<UserDto> Members { get; init; }
    public ICollection<UserDto> Followers { get; init; }
    public ICollection<ArticleDto> Articles { get; init; }
}