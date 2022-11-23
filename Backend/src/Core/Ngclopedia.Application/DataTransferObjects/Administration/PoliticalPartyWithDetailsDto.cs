using Ngclopedia.Application.DataTransferObjects.Common;

namespace Ngclopedia.Application.DataTransferObjects.Administration;

public class PoliticalPartyWithDetailsDto
{
    public Guid PoliticalPartyId { get; init; }
    public string Name { get; init; }
    public string PartyChairman { get; init; }
    public string PartySecretary { get; init; }
    public string GoverningBody { get; init; }
    public DateTime Founded { get; init; }
    public bool Merged { get; init; }
    public string? LogoUrl { get; init; }
    public List<string>? Ideology { get; init; }
    public string Slogan { get; init; }
    public int? EstMembersCount { get; init; }
    public List<string>? colours { get; init; }
    public List<string>? FormerNames { get; init; }
    public List<string> Founders { get; init; }
    public ICollection<PoliticalOfficeDto>? PoliticalOffices { get; init; }
    public ICollection<PoliticalPartyDto>? MergedParties { get; init; }
    public ICollection<AddressDto>? Addresses { get; init; }
    public ICollection<ContactDto>? Contacts { get; init; }
}