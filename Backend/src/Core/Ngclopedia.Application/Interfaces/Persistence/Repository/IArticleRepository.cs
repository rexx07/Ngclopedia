using Ngclopedia.Domain.Forums;

namespace Ngclopedia.Application.Interfaces.Persistence.Repository;

public interface IArticleRepository
{
    Task<IEnumerable<Article>> GetAllArticlesAsync(bool trackChanges);
    Task<Article?> GetArticleAsync(Guid id, bool trackChanges);
    void CreateArticle(Article article);
    void DeleteArticle(Article article);
}