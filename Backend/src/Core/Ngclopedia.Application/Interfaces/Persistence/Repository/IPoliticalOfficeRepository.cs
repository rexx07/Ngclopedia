using Ngclopedia.Domain.Administrations;

namespace Ngclopedia.Application.Interfaces.Persistence.Repository;

public interface IPoliticalOfficeRepository
{
    Task<IEnumerable<PoliticalOffice>> GetAllPoliticalOfficesAsync(bool trackChanges);
    Task<PoliticalOffice?> GetPoliticalOfficeAsync(Guid id, bool trackChanges);
    void CreatePoliticalOffice(PoliticalOffice politicalOffice);
    void DeletePoliticalOffice(PoliticalOffice politicalOffice);
}