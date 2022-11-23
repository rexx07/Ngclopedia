using Microsoft.EntityFrameworkCore;
using Ngclopedia.Application.Authorization;
using Ngclopedia.Application.Caching;
using Ngclopedia.Application.Exceptions;

namespace Ngclopedia.User;

internal partial class UserService
{
    public async Task<List<string>> GetUserPermissionsAsync(string userId, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(userId);

        _ = user ?? throw new UnauthorizedException("Authentication Failed.");

        var userRoles = await _userManager.GetRolesAsync(user);
        var permissions = new List<string>();
        foreach (var role in await _roleManager.Roles
                     .Where(r => userRoles.Contains(r.Name))
                     .ToListAsync(cancellationToken))
            permissions.AddRange(await _db.RoleClaims
                .Where(rc => rc.RoleId == role.Id && rc.ClaimType == NgclopediaClaims.Permission)
                .Select(rc => rc.ClaimValue)
                .ToListAsync(cancellationToken));

        return permissions.Distinct().ToList();
    }

    public async Task<bool> HasPermissionAsync(string userId, string permission, CancellationToken cancellationToken)
    {
        var permissions = await _cache.GetOrSetAsync(
            _cacheKeys.GetCacheKey(NgclopediaClaims.Permission, userId),
            () => GetUserPermissionsAsync(userId, cancellationToken),
            cancellationToken: cancellationToken);

        return permissions?.Contains(permission) ?? false;
    }

    public Task InvalidatePermissionCacheAsync(string userId, CancellationToken cancellationToken)
    {
        return _cache.RemoveAsync(_cacheKeys.GetCacheKey(NgclopediaClaims.Permission, userId), cancellationToken);
    }
}