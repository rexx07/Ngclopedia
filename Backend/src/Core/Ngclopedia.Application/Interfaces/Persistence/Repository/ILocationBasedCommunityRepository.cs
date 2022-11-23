using Ngclopedia.Domain.Communities;

namespace Ngclopedia.Application.Interfaces.Persistence.Repository;

public interface ILocationBasedCommunityRepository
{
    Task<IEnumerable<LocationBasedCommunity>> GetAllLocationBasedCommunitiesAsync(bool trackChanges);
    Task<LocationBasedCommunity?> GetLocationBasedCommunityAsync(Guid id, bool trackChanges);
    void CreateLocationBasedCommunity(LocationBasedCommunity locationBasedCommunity);
    void DeleteLocationBasedCommunity(LocationBasedCommunity locationBasedCommunity);
}