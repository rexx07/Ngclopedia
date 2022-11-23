using Microsoft.AspNetCore.Authorization;
using Ngclopedia.Application.Authorization;

namespace Ngclopedia.Auth.Permissions;

public class MustHavePermissionAttribute : AuthorizeAttribute
{
    public MustHavePermissionAttribute(string action, string resource)
    {
        Policy = NgclopediaPermission.NameFor(action, resource);
    }
}