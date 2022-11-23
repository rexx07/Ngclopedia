using Ngclopedia.Domain.Common;

namespace Ngclopedia.Application.Interfaces.Persistence.Repository;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> GetAllLocationsAsync(bool trackChanges);
    Task<Location?> GetLocationAsync(Guid id, bool trackChanges);
    void CreateLocation(Location location);
    void DeleteLocation(Location location);
}