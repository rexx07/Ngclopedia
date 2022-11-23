using Ngclopedia.Domain.Forums;

namespace Ngclopedia.Application.DataTransferObjects.Community;

public class CreateCategoryBasedCommunityRequestDto
{
    public string Name { get; init; }
    public string Description { get; init; }
    public string? LogoUrl { get; init; }
    public Guid UserId { get; init; }
    public Category PrimaryCategory { get; init; }
    public Category[]? Categories { get; init; }
}