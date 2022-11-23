using Microsoft.AspNetCore.Mvc;
using Ngclopedia.Application.Authorization;
using Ngclopedia.Application.DataTransferObjects.Auth.Roles;
using Ngclopedia.Application.Interfaces.Service.Auth;
using Ngclopedia.Auth.Permissions;
using NSwag.Annotations;

namespace Ngclopedia.WebApi.Controllers.Identity;

public class RolesController: VersionNeutralApiController
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService) =>
        _roleService = roleService;

    [HttpGet]
    [MustHavePermission(NgclopediaAction.View, NgclopediaResource.Roles)]
    [OpenApiOperation("Get a list of all roles.", "")]
    public Task<List<RoleDto>> GetRolesListAsync(CancellationToken cancellationToken) =>
        _roleService.GetListAsync(cancellationToken);

    [HttpGet("{Id}")]
    [MustHavePermission(NgclopediaAction.View, NgclopediaResource.Roles)]
    [OpenApiOperation("Get a role details.", "")]
    public Task<RoleDto> GetByIdAsync(string id) =>
        _roleService.GetByIdAsync(id);

    [HttpGet("{id}/permissions")]
    [MustHavePermission(NgclopediaAction.Update, NgclopediaResource.RoleClaims)]
    [OpenApiOperation("Update a role's permission.", "")]
    public async Task<ActionResult<string>> UpdatePermissionsAsync(string id, UpdateRolePermissionsRequestDto request,
        CancellationToken cancellationToken)
    {
        if (id != request.RoleId)
            return BadRequest();
        var updateResult = await _roleService.UpdatePermissionsAsync(request, cancellationToken);
        
        return updateResult;
    }

    [HttpPost]
    [MustHavePermission(NgclopediaAction.Create, NgclopediaResource.Roles)]
    [OpenApiOperation("Create or update a role.", "")]
    public Task<string> RegisterRoleAsync(CreateOrUpdateRoleRequestDto request) =>
        _roleService.CreateOrUpdateAsync(request);

    [HttpDelete("{Id}")]
    [MustHavePermission(NgclopediaAction.Delete, NgclopediaResource.Roles)]
    [OpenApiOperation("Delete a role.", "")]
    public Task<string> DeleteAsync(string id) =>
        _roleService.DeleteAsync(id);
}