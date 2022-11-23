namespace Ngclopedia.Application.DataTransferObjects.Administration;

public class UpdatePoliticalOfficeRequestDto
{
    public string Name { get; init; }
    public string? AvatarUrl { get; init; }
    public int TermLimits { get; init; }
    public DateTime CurrentTenureStart { get; init; }
    public DateTime CurrentTenureEnd { get; init; }
    public DateTime NextElection { get; init; }
    public List<string> Functions { get; init; }
    public ICollection<Guid> PoliticalOfficesIds { get; init; }
}