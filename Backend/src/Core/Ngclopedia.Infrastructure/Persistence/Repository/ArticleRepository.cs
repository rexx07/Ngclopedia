using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Interfaces.Persistence.Repository;
using Ngclopedia.Domain.Forums;
using Ngclopedia.Infrastructure.Persistence.Context;

namespace Ngclopedia.Infrastructure.Persistence.Repository;

internal sealed class ArticleRepository : RepositoryBase<Article>, IArticleRepository
{
    public ArticleRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Article>> GetAllArticlesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(a => a.Title)
            .ToListAsync();
    }

    public async Task<Article?> GetArticleAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(a => a.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateArticle(Article article)
    {
        Create(article);
    }

    public void DeleteArticle(Article article)
    {
        Delete(article);
    }
}