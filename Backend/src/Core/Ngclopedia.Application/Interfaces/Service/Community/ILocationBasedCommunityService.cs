using Ngclopedia.Application.DataTransferObjects.Community;

namespace Ngclopedia.Application.Interfaces.Service.Community;

public interface ILocationBasedCommunityService
{
    Task<IEnumerable<LocationBasedCommunityDto>> GetAllLocationBasedCommunitiesAsync(bool trackChanges);

    Task<IEnumerable<LocationBasedCommunityDto>> SearchLocationBasedCommunitiesAsync(
        IEnumerable<Guid> locationBasedCommunityIds, bool trackChanges);

    Task<LocationBasedCommunityWithDetailsDto> GetLocationBasedCommunityAsync(Guid locationBasedCommunityId,
        bool trackChanges);

    Task<LocationBasedCommunityDto> CreateLocationBasedCommunityAsync(
        CreateCategoryBasedCommunityRequestDto locationBasedCommunity, bool trackChanges);

    Task UpdateCategoryBasedCommunity(Guid locationBasedCommunityId,
        UpdateLocationBasedCommunityRequestDto locationBasedCommunity, bool trackChanges);
}