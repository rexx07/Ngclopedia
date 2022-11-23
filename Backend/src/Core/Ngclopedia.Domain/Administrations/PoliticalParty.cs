using Ngclopedia.Domain.Common;
using Ngclopedia.Domain.Contracts;

namespace Ngclopedia.Domain.Administrations;

public class PoliticalParty : AuditableEntity
{
    public PoliticalParty(
        string name,
        string partyChairman,
        string partySecretary,
        string governingBody,
        string logoUrl,
        string slogan,
        string ideology,
        int estMembersCount)
    {
        Name = name;
        PartyChairman = partyChairman;
        PartySecretary = partySecretary;
        GoverningBody = governingBody;
        LogoUrl = logoUrl;
        Slogan = slogan;
        Ideology = ideology;
        EstMembersCount = estMembersCount;
    }

    public string Name { get; set; }
    public string PartyChairman { get; set; }
    public string PartySecretary { get; set; }
    public string GoverningBody { get; set; }
    public DateTime Founded { get; set; }
    public bool Merged { get; set; }
    public string LogoUrl { get; set; }
    public string Ideology { get; set; }
    public string Slogan { get; set; }
    public int EstMembersCount { get; set; }
    public List<string> colours { get; set; }
    public List<string>? FormerNames { get; set; }
    public List<string>? Founders { get; set; }
    public ICollection<PoliticalOffice>? PoliticalOffices { get; set; }
    public ICollection<PoliticalParty>? MergedParties { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<Contact> Contacts { get; set; }
}