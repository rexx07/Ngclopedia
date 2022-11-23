using Ngclopedia.Domain.Administrations;

namespace Ngclopedia.Application.DataTransferObjects.Common;

public class UpdateLocationRequestDto
{
    public string Introduction { get; init; }
    public string Pcode { get; init; }
    public string Name { get; init; }
    public AdminType AdminType { get; init; }
    public AdminLevel AdminLevel { get; init; }
    public Continent Continent { get; init; }
}