using Ngclopedia.Domain.Contracts;

namespace Ngclopedia.Domain.Common;

public class Address : AuditableEntity
{
    public Address(
        string name,
        string area,
        string street,
        string building,
        string? apartment,
        string? zipPostalCode,
        AddressType addressType,
        Guid locationId)
    {
        Name = name;
        Area = area;
        Street = street;
        Building = building;
        Apartment = apartment;
        ZipPostalCode = zipPostalCode;
        AddressType = addressType;
        LocationId = locationId;
    }
    public string Name { get; set; }
    public string Area { get; set; }
    public string Street { get; set; }
    public string Building { get; set; }
    public string? Apartment { get; set; }
    public string? ZipPostalCode { get; set; }
    public AddressType AddressType { get; set; }
    public Guid LocationId { get; set; }
    public Location Location { get; set; }
}