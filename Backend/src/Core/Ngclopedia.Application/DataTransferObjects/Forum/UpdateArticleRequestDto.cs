using Ngclopedia.Domain.Common;
using Ngclopedia.Domain.Forums;

namespace Ngclopedia.Application.DataTransferObjects.Forum;

public class UpdateArticleRequestDto
{
    public string Title { get; init; }
    public string Content { get; init; }
    public bool AllowComments { get; init; }
    public Category Category { get; init; }
    public Location Location { get; init; }
    public PublishedStatus PublishedStatus { get; init; }
    public Guid? CommunityId { get; init; }
    public ArticleCommunity ArticleCommunity { get; init; }
    public List<string>? Pictures { get; init; }
    public List<string> Tags { get; init; }
}