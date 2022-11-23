namespace Ngclopedia.Application.DataTransferObjects.Auth.Roles;

public class CreateOrUpdateRoleRequestDto
{
    public string? Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}