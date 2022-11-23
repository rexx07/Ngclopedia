using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Interfaces.Persistence.Repository;
using Ngclopedia.Domain.Common;
using Ngclopedia.Infrastructure.Persistence.Context;

namespace Ngclopedia.Infrastructure.Persistence.Repository;

internal sealed class ContactRepository : RepositoryBase<Contact>, IContactRepository
{
    public ContactRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Contact>> GetAllContactsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Contact?> GetContactAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateContact(Contact contact)
    {
        Create(contact);
    }

    public void DeleteContact(Contact contact)
    {
        Delete(contact);
    }
}