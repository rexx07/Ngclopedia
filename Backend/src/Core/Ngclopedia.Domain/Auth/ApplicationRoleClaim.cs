using Microsoft.AspNetCore.Identity;

namespace Ngclopedia.Domain.Auth;

public class ApplicationRoleClaim : IdentityRoleClaim<string>
{
    public string? CreatedBy { get; init; }
    public DateTime CreatedOn { get; init; }
}