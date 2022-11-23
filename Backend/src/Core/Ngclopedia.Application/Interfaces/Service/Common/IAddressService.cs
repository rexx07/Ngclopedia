using Ngclopedia.Application.DataTransferObjects.Common;

namespace Ngclopedia.Application.Interfaces.Service.Common;

public interface IAddressService
{
    Task<IEnumerable<AddressDto>> GetAllAddressesAsync(bool trackChanges);
    Task<IEnumerable<AddressDto>> SearchAddressAsync(IEnumerable<Guid> addressIds, bool trackChanges);
    Task<AddressDto> GetAddressAsync(Guid addressId, bool trackChanges);
    Task<AddressDto> CreateAddressAsync(CreateAddressRequestDto address, bool trackChanges);
    Task UpdateAddrressAsync(Guid addressId, UpdateAddressRequestDto address, bool trackChanges);
    Task DeleteAddressAsync(Guid addressId, bool trackChanges);
}