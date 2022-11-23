using Microsoft.AspNetCore.Authorization;
using Ngclopedia.Application.Authorization;
using Ngclopedia.Application.Interfaces.Service.User;

namespace Ngclopedia.Auth.Permissions;

internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IUserService _userService;

    public PermissionAuthorizationHandler(IUserService userService)
    {
        _userService = userService;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        if (context.User?.GetUserId() is { } userId &&
            await _userService.HasPermissionAsync(userId, requirement.Permission))
            context.Succeed(requirement);
    }
}