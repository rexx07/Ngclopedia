using Ngclopedia.Domain.Common;
using Ngclopedia.Domain.Contracts;

namespace Ngclopedia.Domain.Administrations;

public class PoliticalOfficeHolder : AuditableEntity
{
    public PoliticalOfficeHolder(
        string firstName,
        string? middleName,
        string? avatarUrl,
        string lastName,
        string almaMater)
    {
        FirstName = firstName;
        MiddleName = middleName;
        AvatarUrl = avatarUrl;
        LastName = lastName;
        AlmaMater = almaMater;
    }

    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string? AvatarUrl { get; set; }
    public List<string>? OtherNames { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<string>? PoliticalAffiliations { get; set; }
    public List<string>? Spouses { get; set; }
    public List<string>? Children { get; set; }
    public List<string>? Occupations { get; set; }
    public List<string>? Relatives { get; set; }
    public string? AlmaMater { get; set; }
    public List<string>? Awards { get; set; }
    public ICollection<PoliticalParty>? PoliticalParties { get; set; }
    public ICollection<PoliticalOffice>? PoliticalOffices { get; set; }
    public ICollection<Contact> Contacts { get; set; }
}