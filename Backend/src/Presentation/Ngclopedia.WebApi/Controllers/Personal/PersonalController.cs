using Microsoft.AspNetCore.Mvc;
using Ngclopedia.Application.Authorization;
using Ngclopedia.Application.DataTransferObjects.Users;
using Ngclopedia.Application.Interfaces.Service.User;
using NSwag.Annotations;

namespace Ngclopedia.WebApi.Controllers.Personal;

public class PersonalController: VersionedApiController
{
    private readonly IUserService _userService;

    public PersonalController(IUserService userService)
        => _userService = userService;

    [HttpGet("profile")]
    [OpenApiOperation("Get profile details of currently logged in user.", "")]
    public async Task<ActionResult<UserWithDetailsDto>> GetProfileAsync(CancellationToken cancellationToken) =>
        User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId)
            ? Unauthorized()
            : Ok( await _userService.GetUserAsync(userId, cancellationToken));

    [HttpPut("profile")]
    [OpenApiOperation("Update profile details of currently logged in user")]
    public async Task<IActionResult> UpdateProfileAsync(UpdateUserRequestDto request)
    {
        if (User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            return Unauthorized();

        await _userService.UpdateUserAsync(request, userId);
        return Ok();
    }

    [HttpPut("change-password")]
    [OpenApiOperation("Change password o currently logged in user.", "")]
    [ApiConventionMethod(typeof(NgclopediaApiConventions), nameof(NgclopediaApiConventions.Register))]
    public async Task<ActionResult> ChangePsswordAsync(ChangePasswordRequestDto request)
    {
        if (User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            return Unauthorized();

        await _userService.ChangePasswordAsync(request, userId);
        return Ok();
    }

    [HttpGet("permissions")]
    [OpenApiOperation("Get permissions of currently logged in user.", "")]
    public async Task<ActionResult<List<string>>> GetPermissionsAsync(CancellationToken cancellationToken) =>
        User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId)
            ? Unauthorized()
            : Ok(await _userService.GetUserPermissionsAsync(userId, cancellationToken));
}