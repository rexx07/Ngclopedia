namespace Ngclopedia.Application.DataTransferObjects.Administration;

public class UpdatePoliticalOfficeHolderRequestDto
{
    public string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public string LastName { get; init; }
    public string? AvatarUrl { get; set; }
    public List<string>? OtherNames { get; init; }
    public DateTime DateOfBirth { get; init; }
    public Guid PoliticalPartyId { get; init; }
    public List<string>? PoliticalAffiliations { get; init; }
    public List<string>? Spouses { get; init; }
    public List<string>? Children { get; init; }
    public List<string>? Occupations { get; init; }
    public List<string>? Relatives { get; init; }
    public string? AlmaMater { get; init; }
    public List<string>? Awards { get; init; }
    public ICollection<Guid>? PoliticalPartyIds { get; init; }
    public ICollection<Guid>? PoliticalOfficeIds { get; init; }
}