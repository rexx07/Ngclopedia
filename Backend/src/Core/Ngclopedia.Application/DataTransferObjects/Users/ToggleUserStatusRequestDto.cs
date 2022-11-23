namespace Ngclopedia.Application.DataTransferObjects.Users;

public class ToggleUserStatusRequestDto
{
    public bool ActivateUser { get; set; }
    public string? UserId { get; set; }
}