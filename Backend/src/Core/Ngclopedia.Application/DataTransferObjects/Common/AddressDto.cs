using Ngclopedia.Domain.Common;

namespace Ngclopedia.Application.DataTransferObjects.Common;

public class AddressDto
{
    public Guid AddressId { get; init; }
    public string Name { get; init; }
    public string Area { get; init; }
    public string Street { get; init; }
    public string Building { get; init; }
    public string? Apartment { get; init; }
    public string? ZipPostalCode { get; init; }
    public AddressType AddressType { get; init; }
    public Location Location { get; init; }
}