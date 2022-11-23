using Ngclopedia.Domain.Common;
using Ngclopedia.Domain.Forums;

namespace Ngclopedia.Application.DataTransferObjects.Forum;

public class ArticleDto
{
    public Guid ArticleId { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public DateTime UpdatedOn { get; init; }
    public Category Category { get; init; }
    public Location Location { get; init; }
    public string AuthorName { get; init; }
    public ArticleCommunity Community { get; init; }
    public bool Edited { get; init; }
    public string? Picture { get; init; }
    public List<string> Tags { get; init; }
    public int TotReactions { get; init; }
    public int TotComments { get; init; }
}