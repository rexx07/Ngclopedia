using Ngclopedia.Application.DataTransferObjects.Common;

namespace Ngclopedia.Application.Interfaces.Service.Common;

public interface ILocationService
{
    Task<IEnumerable<LocationDto>> GetAllLocationsAsync(bool trackChanges);
    Task<IEnumerable<LocationDto>> SearchLocationsAsync(IEnumerable<Guid> locationIds, bool trackChanges);
    Task<LocationDto> GetLocationAsync(Guid locationId, bool trackChanges);
    Task<LocationDto> CreateLocationAsync(CreateLocationRequestDto location, bool trackChanges);
    Task UpdateLocationAsync(Guid locationId, UpdateLocationRequestDto location, bool trackChanges);
    Task DeleteLocationAsync(Guid locationId, bool trackChanges);
}