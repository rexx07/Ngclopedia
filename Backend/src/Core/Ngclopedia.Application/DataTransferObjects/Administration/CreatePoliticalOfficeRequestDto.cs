using Ngclopedia.Domain.Administrations;

namespace Ngclopedia.Application.DataTransferObjects.Administration;

public class CreatePoliticalOfficeRequestDto
{
    public string Name { get; init; }
    public OfficeType Office { get; init; }
    public int TermLimits { get; init; }
    public Guid LocationId { get; init; }
    public DateTime CurrentTenureStart { get; init; }
    public DateTime CurrentTenureEnd { get; init; }
    public DateTime NextElection { get; init; }
}