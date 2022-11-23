namespace Ngclopedia.Application.DataTransferObjects.Common;

public class UpdateContactRequestDto
{
    public string Name { get; init; }
    public string? FacebookName { get; init; }
    public string? TwitterUsername { get; init; }
    public string? InstagramUsername { get; init; }
    public string? WebsiteUrl { get; init; }
    public List<string> PhoneNumbers { get; init; }
    public List<string> Emails { get; init; }
}