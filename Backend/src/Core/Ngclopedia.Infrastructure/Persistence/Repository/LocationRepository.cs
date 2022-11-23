using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Interfaces.Persistence.Repository;
using Ngclopedia.Domain.Common;
using Ngclopedia.Infrastructure.Persistence.Context;

namespace Ngclopedia.Infrastructure.Persistence.Repository;

internal sealed class LocationRepository : RepositoryBase<Location>, ILocationRepository
{
    public LocationRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Location>> GetAllLocationsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(l => l.Name)
            .ToListAsync();
    }

    public async Task<Location?> GetLocationAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(l => l.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateLocation(Location location)
    {
        Create(location);
    }

    public void DeleteLocation(Location location)
    {
        Delete(location);
    }
}