using Ngclopedia.Application.DataTransferObjects.Administration;

namespace Ngclopedia.Application.Interfaces.Service.Administration;

public interface IPoliticalPartyService
{
    Task<IEnumerable<PoliticalPartyDto>> GetAllPoliticalPartiesAsync(bool trackChanges);

    Task<IEnumerable<PoliticalPartyDto>> SearchPoliticalPartiesAsync(IEnumerable<Guid> politicalPartyIds,
        bool trackChanges);

    Task<PoliticalPartyWithDetailsDto> GetPoliticalPartyAsync(Guid politicalPartyId, bool trackChanges);
    Task<PoliticalPartyDto> CreatePoliticalPartyAsync(CreatePoliticalPartyRequestDto politicalParty);

    Task UpdatePoliticalPartyAsync(Guid politicalPartyId, UpdatePoliticalPartyRequestDto politicalParty,
        bool trackChanges);

    Task DeleteAsync(Guid politicalPartyId, bool trackChanges);
}