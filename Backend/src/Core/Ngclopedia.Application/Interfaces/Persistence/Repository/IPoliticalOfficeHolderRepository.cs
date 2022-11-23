using Ngclopedia.Domain.Administrations;

namespace Ngclopedia.Application.Interfaces.Persistence.Repository;

public interface IPoliticalOfficeHolderRepository
{
    Task<IEnumerable<PoliticalOfficeHolder>> GetAllPoliticalOfficeHoldersAsync(bool trackChanges);
    Task<PoliticalOfficeHolder?> GetPoliticalOfficeHolderAsync(Guid id, bool trackChanges);
    void CreatePoliticalOfficeHolder(PoliticalOfficeHolder politicalOfficeHolder);
    void DeletePoliticalOfficeHolder(PoliticalOfficeHolder politicalOfficeHolder);
}