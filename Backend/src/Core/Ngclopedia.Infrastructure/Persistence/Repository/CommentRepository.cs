using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Interfaces.Persistence.Repository;
using Ngclopedia.Domain.Forums;
using Ngclopedia.Infrastructure.Persistence.Context;

namespace Ngclopedia.Infrastructure.Persistence.Repository;

internal sealed class CommentRepository : RepositoryBase<Comment>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Comment>> GetAllCommentsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(c => c.Parent)
            .ToListAsync();
    }

    public async Task<Comment?> GetCommentAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateComment(Comment comment)
    {
        Create(comment);
    }

    public void DeleteComment(Comment comment)
    {
        Delete(comment);
    }
}