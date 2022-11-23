using Ngclopedia.Domain.Common;
using Ngclopedia.Domain.Contracts;

namespace Ngclopedia.Domain.Administrations;

public class PoliticalOffice : AuditableEntity
{
    public PoliticalOffice(
        string name,
        OfficeType office,
        string? avatarUrl,
        int termLimits,
        Guid locationId)
    {
        Name = name;
        Office = office;
        AvatarUrl = avatarUrl;
        TermLimits = termLimits;
        LocationId = locationId;
    }

    public string Name { get; set; }
    public OfficeType Office { get; set; }
    public string? AvatarUrl { get; set; }
    public int TermLimits { get; set; }
    public Guid LocationId { get; set; }
    public Location Location { get; set; }
    public DateTime CurrentTenureStart { get; set; }
    public DateTime CurrentTenureEnd { get; set; }
    public DateTime NextElection { get; set; }
    public List<string> Functions { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<PoliticalOfficeHolder> PoliticalOfficeHolders { get; set; }
}