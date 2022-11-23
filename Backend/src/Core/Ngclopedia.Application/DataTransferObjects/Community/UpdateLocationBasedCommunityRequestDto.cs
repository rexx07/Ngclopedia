namespace Ngclopedia.Application.DataTransferObjects.Community;

public class UpdateLocationBasedCommunityRequestDto
{
    public string Name { get; init; }
    public string Description { get; init; }
    public string LogoUrl { get; init; }
    public List<string>? Rules { get; init; }
    public List<string>? FAQ { get; init; }
    public List<string>? Info { get; init; }
}