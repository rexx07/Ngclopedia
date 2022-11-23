using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Interfaces.Persistence.Repository;
using Ngclopedia.Domain.Communities;
using Ngclopedia.Infrastructure.Persistence.Context;

namespace Ngclopedia.Infrastructure.Persistence.Repository;

internal sealed class LocationBasedCommunityRepository : RepositoryBase<LocationBasedCommunity>,
    ILocationBasedCommunityRepository
{
    public LocationBasedCommunityRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<LocationBasedCommunity>> GetAllLocationBasedCommunitiesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(lbc => lbc.Name)
            .ToListAsync();
    }

    public async Task<LocationBasedCommunity?> GetLocationBasedCommunityAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(lbc => lbc.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateLocationBasedCommunity(LocationBasedCommunity locationBasedCommunity)
    {
        Create(locationBasedCommunity);
    }

    public void DeleteLocationBasedCommunity(LocationBasedCommunity locationBasedCommunity)
    {
        Delete(locationBasedCommunity);
    }
}