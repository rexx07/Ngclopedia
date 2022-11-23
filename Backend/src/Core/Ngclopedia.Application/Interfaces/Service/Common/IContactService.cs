using Ngclopedia.Application.DataTransferObjects.Common;

namespace Ngclopedia.Application.Interfaces.Service.Common;

public interface IContactService
{
    Task<IEnumerable<ContactDto>> GetAllContactsAsync(bool trackChanges);
    Task<IEnumerable<ContactDto>> SearchContactsAsync(IEnumerable<Guid> contactId, bool trackChanges);
    Task<ContactDto> GetContactAsync(Guid contactId, bool trackChanges);
    Task<ContactDto> CreateContactAsync(CreateContactRequestDto contact, bool trackChanges);
    Task UpdateContactAsync(Guid contactId, UpdateContactRequestDto contact, bool trackChanges);
    Task DeleteContactAsync(Guid contactId, bool trackChanges);
}