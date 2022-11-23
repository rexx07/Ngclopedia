using Microsoft.AspNetCore.Authorization;

namespace Ngclopedia.Auth.Permissions;

internal class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }

    public string Permission { get; }
}