namespace Ngclopedia.Application.DataTransferObjects.Administration;

public class PoliticalOfficeHolderDto
{
    public Guid PoliticalOfficeHolderId { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? AvatarUrl { get; init; }
    public DateTime DateOfBirth { get; set; }
    public string PoliticalPartyName { get; set; }
}