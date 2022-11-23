using Ngclopedia.Application.DataTransferObjects.Administration;

namespace Ngclopedia.Application.Interfaces.Service.Administration;

public interface IPoliticalOfficeHolderService
{
    Task<IEnumerable<PoliticalOfficeHolderDto>> GetAllPoliticalOfficeHoldersAsync(bool trackChanges);

    Task<IEnumerable<PoliticalOfficeHolderDto>> SearchPoliticalOfficeHoldersAsync(
        IEnumerable<Guid> politicalOfficeHolderIds, bool trackChanges);

    Task<PoliticalOfficeHolderWithDetailsDto> GetPoliticalOfficeHolderAsync(Guid politicalOfficeHolderId,
        bool trackChanges);

    Task CreatePoliticalOfficeHolderAsync(CreatePoliticalOfficeHolderRequestDto politicalOfficeHolder,
        bool trackChanges);

    Task UpdatePoliticalOfficeHolderAsync(Guid politicalOfficeHolderId,
        UpdatePoliticalOfficeHolderRequestDto politicalOfficeHolder, bool trackChanges);

    Task DeletePoliticalOfficeHolderAsync(Guid politicalOfficeHolderId, bool trackChanges);
}