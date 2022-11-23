using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Authorization;
using Ngclopedia.Application.DataTransferObjects.Users;
using Ngclopedia.Application.Exceptions;
using Ngclopedia.User.Events;

namespace Ngclopedia.User;

internal partial class UserService
{
    public async Task<List<UserRoleDto>> GetUserRolesAsync(string userId, CancellationToken cancellationToken)
    {
        var userRoles = new List<UserRoleDto>();

        var user = await _userManager.FindByIdAsync(userId);
        var roles = await _roleManager.Roles.AsNoTracking().ToListAsync(cancellationToken);
        foreach (var role in roles)
            userRoles.Add(new UserRoleDto
            {
                RoleId = role.Id,
                RoleName = role.Name,
                Description = role.Description,
                Enabled = await _userManager.IsInRoleAsync(user, role.Name)
            });

        return userRoles;
    }

    public async Task<string> AssignUserRolesAsync(string userId, UserRolesRequestDto request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var user = await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync(cancellationToken);

        _ = user ?? throw new NotFoundException(_t["User Not Found."]);

        // Check if the user is an admin for which the admin||Superuser||Root role is getting disabled
        if (await _userManager.IsInRoleAsync(user, NgclopediaRoles.Admin)
            || await _userManager.IsInRoleAsync(user, NgclopediaRoles.Superuser)
            || (await _userManager.IsInRoleAsync(user, NgclopediaRoles.Root)
                && request.UserRoles.Any(a => !a.Enabled && a.RoleName is NgclopediaRoles.Admin
                    or NgclopediaRoles.Superuser or NgclopediaRoles.Root)))
        {
            // Get count of users in Admin||Superuser||Root Role
            var adminCount = (await _userManager.GetUsersInRoleAsync(NgclopediaRoles.Admin)).Count;
            var superUserCount = (await _userManager.GetUsersInRoleAsync(NgclopediaRoles.Superuser)).Count;
            var rootCount = (await _userManager.GetUsersInRoleAsync(NgclopediaRoles.Root)).Count;

            // Check if user is not Root Tenant Admin
            // Edge Case : there are chances for other tenants to have users with the same email as that of Root Tenant Admin. Probably can add a check while User Registration
            if (await _userManager.IsInRoleAsync(user, NgclopediaRoles.Root))
                throw new ConflictException(_t["Cannot Remove Admin Role From Root Tenant Admin."]);
            if (adminCount <= 2)
                throw new ConflictException(_t["Should have at least 2 Admins."]);
            if (superUserCount <= 2)
                throw new ConflictException(_t["Should have at least 2 Superusers."]);
            if (rootCount <= 2) throw new ConflictException(_t["Should have at least 2 Roots."]);
        }

        foreach (var userRole in request.UserRoles)
            // Check if Role Exists
            if (await _roleManager.FindByNameAsync(userRole.RoleName) is not null)
            {
                if (userRole.Enabled)
                {
                    if (!await _userManager.IsInRoleAsync(user, userRole.RoleName))
                        await _userManager.AddToRoleAsync(user, userRole.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, userRole.RoleName);
                }
            }

        await _events.PublishAsync(new ApplicationUserUpdatedEvent(user.Id, true));

        return _t["User Roles Updated Successfully."];
    }
}