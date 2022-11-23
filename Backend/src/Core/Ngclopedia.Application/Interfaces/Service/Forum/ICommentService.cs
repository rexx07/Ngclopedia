using Ngclopedia.Application.DataTransferObjects.Forum;

namespace Ngclopedia.Application.Interfaces.Service.Forum;

public interface ICommentService
{
    Task<IEnumerable<CommentDto>> GetAllCommentsAsync(bool trackChanges);
    Task<IEnumerable<CommentDto>> SearchCommentsAsync(IEnumerable<Guid> commentIds, bool trackChanges);
    Task<CommentWithDetailsDto> GetCommentAsync(Guid commentId, bool trackChanges);

    Task<CommentDto> CreateCommentAsync(CreateUpdateCommentRequestDto comment, bool trackChanges);

    Task UpdateCommentAsync(Guid commentId, CommentDto comment, bool trackChanges);
    Task DeleteCommentAsync(Guid commentId, bool trackChanges);
}