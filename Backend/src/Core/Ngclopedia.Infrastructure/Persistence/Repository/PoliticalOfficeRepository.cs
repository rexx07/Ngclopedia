using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Interfaces.Persistence.Repository;
using Ngclopedia.Domain.Administrations;
using Ngclopedia.Infrastructure.Persistence.Context;

namespace Ngclopedia.Infrastructure.Persistence.Repository;

internal sealed class PoliticalOfficeRepository : RepositoryBase<PoliticalOffice>, IPoliticalOfficeRepository
{
    public PoliticalOfficeRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<PoliticalOffice>> GetAllPoliticalOfficesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(po => po.Name)
            .ToListAsync();
    }

    public async Task<PoliticalOffice?> GetPoliticalOfficeAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(po => po.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreatePoliticalOffice(PoliticalOffice politicalOffice)
    {
        Create(politicalOffice);
    }

    public void DeletePoliticalOffice(PoliticalOffice politicalOffice)
    {
        Delete(politicalOffice);
    }
}