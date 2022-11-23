using Ngclopedia.Application.DataTransferObjects.Common;
using Ngclopedia.Domain.Administrations;

namespace Ngclopedia.Application.DataTransferObjects.Administration;

public class PoliticalOfficeWithDetailsDto
{
    public Guid PoliticalOfficeId { get; init; }
    public string Name { get; init; }
    public string? AvatarUrl { get; init; }
    public OfficeType Office { get; init; }
    public int TermLimits { get; init; }
    public LocationDto Location { get; init; }
    public DateTime CurrentTenureStart { get; init; }
    public DateTime CurrentTenureEnd { get; init; }
    public DateTime NextElection { get; init; }
    public List<string> Functions { get; init; }
    public ICollection<ContactDto> Contacts { get; init; }
    public ICollection<AddressDto> Addresses { get; init; }
    public ICollection<PoliticalOfficeHolderDto> OfficeHolders { get; init; }
}