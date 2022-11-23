using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Interfaces.Persistence.Repository;
using Ngclopedia.Domain.Administrations;
using Ngclopedia.Infrastructure.Persistence.Context;

namespace Ngclopedia.Infrastructure.Persistence.Repository;

internal sealed class PoliticalPartyRepository : RepositoryBase<PoliticalParty>, IPoliticalPartyRepository
{
    public PoliticalPartyRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<PoliticalParty>> GetAllReactionsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(pp => pp.Name)
            .ToListAsync();
    }

    public async Task<PoliticalParty?> GetPoliticalPartyAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(pp => pp.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreatePoliticalParty(PoliticalParty politicalParty)
    {
        Create(politicalParty);
    }

    public void DeletePoliticalParty(PoliticalParty politicalParty)
    {
        Delete(politicalParty);
    }
}