using Ngclopedia.Application.DataTransferObjects.Community;

namespace Ngclopedia.Application.Interfaces.Service.Community;

public interface ICategoryBasedCommunityService
{
    Task<IEnumerable<CategoryBasedCommunityDto>> GetAllCategoryBasedCommunitiesAsync(bool trackChanges);

    Task<IEnumerable<CategoryBasedCommunityDto>> SearchCategoryBasedCommunitiesAsync(
        IEnumerable<Guid> categoryBasedCommunityIds, bool trackChanges);

    Task<CategoryBasedCommunityWithDetailsDto> GetCategoryBasedCommunityAsync(Guid categoryBasedCommunityId,
        bool trackChanges);

    Task<CategoryBasedCommunityDto> CreateCategoryBasedCommunityAsync(
        CreateCategoryBasedCommunityRequestDto categoryBasedCommunity, bool trackChanges);

    Task UpdateCategoryBasedCommunity(Guid categoryBasedCommunityId,
        UpdateCategoryBasedCommunityRequestDto categoryBasedCommunity, bool trackChanges);

    Task DeleteCategoryBasedCommunity(Guid communityId, bool trackChanges);
}