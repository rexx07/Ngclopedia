using Ngclopedia.Application.DataTransferObjects.Common;
using Ngclopedia.Application.DataTransferObjects.Forum;
using Ngclopedia.Application.DataTransferObjects.Users;
using Ngclopedia.Domain.Forums;

namespace Ngclopedia.Application.DataTransferObjects.Community;

public class CategoryBasedCommunityWithDetailsDto
{
    public Guid CategoryBasedCommunityId { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string LogoUrl { get; init; }
    public string CreatorName { get; init; }
    public ContactDto Contact { get; init; }
    public List<UserDto> Excos { get; init; }
    public List<string> Rules { get; init; }
    public List<string> FAQ { get; init; }
    public List<string> Info { get; init; }
    public Category PrimaryCategory { get; init; }
    public Category[]? Categories { get; init; }
    public ICollection<UserDto> Members { get; init; }
    public ICollection<UserDto> Followers { get; init; }
    public ICollection<ArticleDto> Articles { get; init; }
}