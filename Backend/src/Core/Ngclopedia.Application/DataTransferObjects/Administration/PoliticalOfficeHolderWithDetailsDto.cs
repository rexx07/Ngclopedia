using Ngclopedia.Application.DataTransferObjects.Common;

namespace Ngclopedia.Application.DataTransferObjects.Administration;

public class PoliticalOfficeHolderWithDetailsDto
{
    public Guid PoliticalOfficeHolderId { get; init; }
    public string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public string LastName { get; init; }
    public string? AvatarUrl { get; init; }
    public List<string>? OtherNames { get; init; }
    public DateTime DateOfBirth { get; init; }
    public List<string>? PoliticalAffiliations { get; init; }
    public List<string>? Spouses { get; init; }
    public List<string>? Children { get; init; }
    public List<string>? Occupations { get; init; }
    public List<string>? Relatives { get; init; }
    public string? AlmaMater { get; init; }
    public List<string>? Awards { get; init; }
    public ICollection<PoliticalPartyDto>? PoliticalParties { get; init; }
    public ICollection<PoliticalOfficeDto>? PoliticalOffices { get; init; }
    public ICollection<ContactDto> Contacts { get; init; }
}