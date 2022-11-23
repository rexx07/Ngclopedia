using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Ngclopedia.Application.Authorization;
using Ngclopedia.Application.DataTransferObjects.Auth.Roles;
using Ngclopedia.Application.Exceptions;
using Ngclopedia.Application.Interfaces.Common;
using Ngclopedia.Application.Interfaces.Service.Auth;
using Ngclopedia.Auth.Extensions;
using Ngclopedia.Domain.Auth;
using Ngclopedia.Domain.Users;
using Ngclopedia.Infrastructure.Persistence.Context;

namespace Ngclopedia.Auth.Services;

internal class RoleService : IRoleService
{
    private readonly ICurrentUser _currentUser;
    private readonly ApplicationDbContext _db;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IStringLocalizer _t;
    private readonly UserManager<ApplicationUser> _userManager;

    public RoleService(
        RoleManager<ApplicationRole> roleManager,
        UserManager<ApplicationUser> userManager,
        ApplicationDbContext db,
        IStringLocalizer<RoleService> localizer,
        ICurrentUser currentUser)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _db = db;
        _t = localizer;
        _currentUser = currentUser;
    }

    public async Task<List<RoleDto>> GetListAsync(CancellationToken cancellationToken)
    {
        return await _roleManager.Roles.Select(r => new RoleDto
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description
        }).ToListAsync(cancellationToken);
    }


    public async Task<int> GetCountAsync(CancellationToken cancellationToken)
    {
        return await _roleManager.Roles.CountAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(string roleName, string? excludeId)
    {
        return await _roleManager.FindByNameAsync(roleName)
                   is ApplicationRole existingRole
               && existingRole.Id != excludeId;
    }

    public async Task<RoleDto> GetByIdAsync(string id)
    {
        return await _db.Roles.Select(ir => new RoleDto
               {
                   Id = ir.Id,
                   Name = ir.Name
               }).SingleOrDefaultAsync(x => x.Id == id)
               ?? throw new NotFoundException(_t["Role Not Found"]);
    }


    public async Task<RoleDto> GetByIdWithPermissionsAsync(string roleId, CancellationToken cancellationToken)
    {
        var role = await GetByIdAsync(roleId);

        role.Permissions = await _db.RoleClaims
            .Where(c => c.RoleId == roleId && c.ClaimType == NgclopediaClaims.Permission)
            .Select(c => c.ClaimValue)
            .ToListAsync(cancellationToken);

        return role;
    }

    public async Task<string> CreateOrUpdateAsync(CreateOrUpdateRoleRequestDto request)
    {
        if (string.IsNullOrEmpty(request.Id))
        {
            // Create a new role.
            var role = new ApplicationRole(request.Name, request.Description);
            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded) throw new InternalServerException(_t["Register role failed"], result.GetErrors(_t));

            return string.Format(_t["Role {0} Created."], request.Name);
        }
        else
        {
            // Update an existing role.
            var role = await _roleManager.FindByIdAsync(request.Id);

            _ = role ?? throw new NotFoundException(_t["Role Not Found"]);

            if (NgclopediaRoles.IsDefault(role.Name))
                throw new ConflictException(string.Format(_t["Not allowed to modify {0} Role."], role.Name));

            role.Name = request.Name;
            role.NormalizedName = request.Name.ToUpperInvariant();
            role.Description = request.Description;
            var result = await _roleManager.UpdateAsync(role);

            if (!result.Succeeded) throw new InternalServerException(_t["Update role failed"], result.GetErrors(_t));

            return string.Format(_t["Role {0} Updated."], role.Name);
        }
    }

    public async Task<string> UpdatePermissionsAsync(UpdateRolePermissionsRequestDto request,
        CancellationToken cancellationToken)
    {
        var role = await _roleManager.FindByIdAsync(request.RoleId);
        _ = role ?? throw new NotFoundException(_t["Role Not Found"]);
        if (role.Name == NgclopediaRoles.Admin)
            throw new ConflictException(_t["Not allowed to modify Permissions for this Role."]);

        var currentClaims = await _roleManager.GetClaimsAsync(role);

        // Remove permissions that were previously selected
        foreach (var claim in currentClaims.Where(c => request.Permissions.All(p => p != c.Value)))
        {
            var removeResult = await _roleManager.RemoveClaimAsync(role, claim);
            if (!removeResult.Succeeded)
                throw new InternalServerException(_t["Update permissions failed."], removeResult.GetErrors(_t));
        }

        // Add all permissions that were not previously selected
        foreach (var permission in request.Permissions.Where(c => currentClaims.All(p => p.Value != c)))
            if (!string.IsNullOrEmpty(permission))
            {
                _db.RoleClaims.Add(new ApplicationRoleClaim
                {
                    RoleId = role.Id,
                    ClaimType = NgclopediaClaims.Permission,
                    ClaimValue = permission,
                    CreatedBy = _currentUser.GetUserId().ToString()
                });
                await _db.SaveChangesAsync(cancellationToken);
            }

        return _t["Permissions Updated."];
    }

    public async Task<string> DeleteAsync(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);

        _ = role ?? throw new NotFoundException(_t["Role Not Found"]);

        if (NgclopediaRoles.IsDefault(role.Name))
            throw new ConflictException(string.Format(_t["Not allowed to delete {0} Role."], role.Name));

        if ((await _userManager.GetUsersInRoleAsync(role.Name)).Count > 0)
            throw new ConflictException(string.Format(_t["Not allowed to delete {0} Role as it is being used."],
                role.Name));

        await _roleManager.DeleteAsync(role);

        return string.Format(_t["Role {0} Deleted."], role.Name);
    }
}