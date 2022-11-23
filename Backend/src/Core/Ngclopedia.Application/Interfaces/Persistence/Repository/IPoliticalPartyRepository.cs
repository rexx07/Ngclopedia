using Ngclopedia.Domain.Administrations;

namespace Ngclopedia.Application.Interfaces.Persistence.Repository;

public interface IPoliticalPartyRepository
{
    Task<IEnumerable<PoliticalParty>> GetAllReactionsAsync(bool trackChanges);
    Task<PoliticalParty?> GetPoliticalPartyAsync(Guid id, bool trackChanges);
    void CreatePoliticalParty(PoliticalParty politicalParty);
    void DeletePoliticalParty(PoliticalParty politicalParty);
}