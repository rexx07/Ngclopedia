using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Interfaces.Persistence.Repository;
using Ngclopedia.Domain.Communities;
using Ngclopedia.Infrastructure.Persistence.Context;

namespace Ngclopedia.Infrastructure.Persistence.Repository;

internal sealed class CategoryBasedCommunityRepository : RepositoryBase<CategoryBasedCommunity>,
    ICategoryBasedCommunityRepository
{
    public CategoryBasedCommunityRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<CategoryBasedCommunity>> GetAllCategoryBasedCommunitiesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(cbc => cbc.Name)
            .ToListAsync();
    }

    public async Task<CategoryBasedCommunity?> GetCategoryBasedCommunityAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(cbc => cbc.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateCategoryBasedCommunity(CategoryBasedCommunity categoryBasedCommunity)
    {
        Create(categoryBasedCommunity);
    }

    public void DeleteCategoryBasedCommunity(CategoryBasedCommunity categoryBasedCommunity)
    {
        Delete(categoryBasedCommunity);
    }
}