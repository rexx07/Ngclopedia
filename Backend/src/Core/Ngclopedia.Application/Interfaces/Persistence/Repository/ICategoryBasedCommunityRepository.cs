using Ngclopedia.Domain.Communities;

namespace Ngclopedia.Application.Interfaces.Persistence.Repository;

public interface ICategoryBasedCommunityRepository
{
    Task<IEnumerable<CategoryBasedCommunity>> GetAllCategoryBasedCommunitiesAsync(bool trackChanges);
    Task<CategoryBasedCommunity?> GetCategoryBasedCommunityAsync(Guid id, bool trackChanges);
    void CreateCategoryBasedCommunity(CategoryBasedCommunity categoryBasedCommunity);
    void DeleteCategoryBasedCommunity(CategoryBasedCommunity categoryBasedCommunity);
}