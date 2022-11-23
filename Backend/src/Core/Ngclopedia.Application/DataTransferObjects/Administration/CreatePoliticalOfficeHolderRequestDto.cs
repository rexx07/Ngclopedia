namespace Ngclopedia.Application.DataTransferObjects.Administration;

public class CreatePoliticalOfficeHolderRequestDto
{
    public string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public DateTime DateOfBirth { get; init; }
    public Guid PoliticalPartyId { get; init; }
    public Guid PoliticalOfficeId { get; init; }
}