using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Interfaces.Persistence.Repository;
using Ngclopedia.Domain.Administrations;
using Ngclopedia.Infrastructure.Persistence.Context;

namespace Ngclopedia.Infrastructure.Persistence.Repository;

internal sealed class PoliticalOfficeHolderRepository : RepositoryBase<PoliticalOfficeHolder>,
    IPoliticalOfficeHolderRepository
{
    public PoliticalOfficeHolderRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<PoliticalOfficeHolder>> GetAllPoliticalOfficeHoldersAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(poh => poh.FirstName)
            .ToListAsync();
    }

    public async Task<PoliticalOfficeHolder?> GetPoliticalOfficeHolderAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(poh => poh.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreatePoliticalOfficeHolder(PoliticalOfficeHolder politicalOfficeHolder)
    {
        Create(politicalOfficeHolder);
    }

    public void DeletePoliticalOfficeHolder(PoliticalOfficeHolder politicalOfficeHolder)
    {
        Delete(politicalOfficeHolder);
    }
}