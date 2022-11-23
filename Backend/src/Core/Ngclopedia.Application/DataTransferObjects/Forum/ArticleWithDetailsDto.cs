using Ngclopedia.Domain.Common;
using Ngclopedia.Domain.Forums;

namespace Ngclopedia.Application.DataTransferObjects.Forum;

public class ArticleWithDetailsDto
{
    public string Title { get; init; }
    public string Content { get; init; }
    public DateTime UpdatedOn { get; init; }
    public Category Category { get; init; }
    public Location Location { get; init; }
    public PublishedStatus PublishedStatus { get; init; }
    public string Username { get; init; }
    public ArticleCommunity ArticleCommunity { get; init; }
    public bool Edited { get; init; }
    public List<string>? Edits { get; init; }
    public List<DateTime>? EditsTimes { get; init; }
    public List<string>? Pictures { get; init; }
    public List<string> Tags { get; init; }
    public ICollection<ReactionDto>? Reactions { get; init; }
    public ICollection<CommentDto>? Comments { get; init; }
}