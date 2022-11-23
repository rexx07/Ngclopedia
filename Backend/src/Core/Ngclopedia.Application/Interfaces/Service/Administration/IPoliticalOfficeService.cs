using Ngclopedia.Application.DataTransferObjects.Administration;

namespace Ngclopedia.Application.Interfaces.Service.Administration;

public interface IPoliticalOfficeService
{
    Task<IEnumerable<PoliticalOfficeDto>> GetAllPoliticalOfficesAsync(bool trackChanges);

    Task<IEnumerable<PoliticalOfficeDto>> SearchPoliticalOfficesAsync(IEnumerable<Guid> politicalOfficeIds,
        bool trackChanges);

    Task<PoliticalOfficeWithDetailsDto> GetPoliticalOfficeAsync(Guid politicalOfficeId, bool trackChanges);
    Task<PoliticalOfficeDto> CreatePoliticalOffice(CreatePoliticalOfficeRequestDto politicalOffice, bool trackChanges);

    Task UpdatePoliticalOfficeAsync(Guid politicalOfficeId, UpdatePoliticalOfficeRequestDto politicalOfficeRequest,
        bool trackChanges);

    Task DeletePoliticalOfficeAsync(Guid politicalOfficeId, bool trackChanges);
}