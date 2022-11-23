using Ngclopedia.Domain.Forums;

namespace Ngclopedia.Application.DataTransferObjects.Forum;

public class ReactionDto
{
    public Guid ReactionId { get; init; }
    public UserReaction ReactionType { get; init; }
}