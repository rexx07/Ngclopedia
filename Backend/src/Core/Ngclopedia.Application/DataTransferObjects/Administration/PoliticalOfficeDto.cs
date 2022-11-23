using Ngclopedia.Domain.Administrations;

namespace Ngclopedia.Application.DataTransferObjects.Administration;

public class PoliticalOfficeDto
{
    public Guid PoliticalOfficeId { get; init; }
    public string Name { get; init; }
    public string? AvatarUrl { get; init; }
    public OfficeType Office { get; init; }
    public int TermLimits { get; init; }
    public string LocationName { get; init; }
    public DateTime CurrentTenureStart { get; init; }
    public DateTime CurrentTenureEnd { get; init; }
}