namespace Ngclopedia.Application.DataTransferObjects.Administration;

public class UpdatePoliticalPartyRequestDto
{
    public string Name { get; init; }
    public string? AvatarUrl { get; init; }
    public string PartyChairman { get; init; }
    public string PartySecretary { get; init; }
    public string GoverningBody { get; init; }
    public DateTime Founded { get; init; }
    public string Logo { get; init; }
    public string Ideology { get; init; }
    public string Slogan { get; init; }
    public int EstMembersCount { get; init; }
    public List<string> colours { get; init; }
    public List<string>? FormerNames { get; init; }
    public List<string>? Founders { get; init; }
    public ICollection<Guid> PoliticalOfficesIds { get; init; }
}