using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ngclopedia.Application.Authorization;
using Ngclopedia.Application.DataTransferObjects.Users;
using Ngclopedia.Application.Interfaces.Service.User;
using Ngclopedia.Auth.Permissions;
using NSwag.Annotations;

namespace Ngclopedia.WebApi.Controllers.Identity;

public class UsersController: VersionNeutralApiController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService) =>
        _userService = userService;

    [HttpGet]
    [MustHavePermission(NgclopediaAction.View, NgclopediaResource.Users)]
    [OpenApiOperation("Get a list of all users")]
    public Task<List<UserDto>> GetListAsync(CancellationToken cancellationToken) =>
        _userService.GetAllUsersAsync(cancellationToken);

    [HttpGet]
    [MustHavePermission(NgclopediaAction.View, NgclopediaResource.Users)]
    [OpenApiOperation("Get a user's detail.", "")]
    public Task<UserWithDetailsDto> GetByIdAsync(string id, CancellationToken cancellationToken) =>
        _userService.GetUserAsync(id, cancellationToken);

    [HttpGet]
    [MustHavePermission(NgclopediaAction.View, NgclopediaResource.UserRoles)]
    [OpenApiOperation("Get a user's role.", "")]
    public Task<List<UserRoleDto>> GetRolesAsync(string id, CancellationToken cancellationToken) =>
        _userService.GetUserRolesAsync(id, cancellationToken);

    [HttpPost("{id}/roles")]
    [ApiConventionMethod(typeof(NgclopediaApiConventions), nameof(NgclopediaApiConventions.Register))]
    [MustHavePermission(NgclopediaAction.Update, NgclopediaResource.UserRoles)]
    public Task<string> AssignRolesAsync(string id, UserRolesRequestDto request, CancellationToken cancellationToken) =>
        _userService.AssignUserRolesAsync(id, request, cancellationToken);

    [HttpPost]
    [MustHavePermission(NgclopediaAction.Create, NgclopediaResource.Users)]
    [OpenApiOperation("Create a new user.", "")]
    public Task<string> CreateAsync(CreateUserRequestDto request)
    {
        // TODO: check if registering anonymous users is actually allowed (should probably be an appsetting)
        // and return UnAuthorized when it isn't
        // Also: add other protection to prevent automatic posting (captcha?)
        return _userService.CreateUserAsync(request, GetOriginFromRequest());
    }

    [HttpPost("self-register")]
    [AllowAnonymous]
    [OpenApiOperation("Anonymous User creates abstract user")]
    public Task<string> SelfRegisterUser(CreateUserRequestDto request)
    {
        // TODO: check if registering anonymous users is actually allowed (should probably be an appsetting)
        // and return UnAuthorized when it isn't
        // Also: add other protection to prevent automatic posting (captcha?)
        return _userService.CreateUserAsync(request, GetOriginFromRequest());
    }

    [HttpPost("{id}/toggle-status")]
    [MustHavePermission(NgclopediaAction.Update, NgclopediaResource.Users)]
    [ApiConventionMethod(typeof(NgclopediaApiConventions), nameof(NgclopediaApiConventions.Register))]
    [OpenApiOperation("Toggle a user's active status", "")]
    public async Task<ActionResult> ToggleStatusAsync(string id, ToggleUserStatusRequestDto request,
        CancellationToken cancellationToken)
    {
        if (id != request.UserId)
            return BadRequest();
        await _userService.ToggleUserStatusAsync(request, cancellationToken);

        return Ok();
    }

    [HttpGet("confirm-email")]
    [AllowAnonymous]
    [OpenApiOperation("Confirm email address for a user.", "")]
    [ApiConventionMethod(typeof(NgclopediaApiConventions), nameof(NgclopediaApiConventions.Search))]
    public Task<string> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code,
        CancellationToken cancellationToken) =>
        _userService.ConfirmEmailAsync(userId, code, cancellationToken);


    [HttpGet("confirm-phone-number")]
    [AllowAnonymous]
    [OpenApiOperation("Confirm phone number for a user", "")]
    [ApiConventionMethod(typeof(NgclopediaApiConventions), nameof(NgclopediaApiConventions.Search))]
    public Task<string> ConfirmPhoneNumberAsync([FromQuery] string userId, [FromQuery] string code) =>
        _userService.ConfirmPhoneNumberAsync(userId, code);

    [HttpPost("forgot-password")]
    [AllowAnonymous]
    [OpenApiOperation("Request a password reset email for a user.", "")]
    [ApiConventionMethod(typeof(NgclopediaApiConventions), nameof(NgclopediaApiConventions.Register))]
    public Task<string> ForgotPasswordAsync(ForgotPasswordRequestDto request) =>
        _userService.ForgotPasswordAsync(request, GetOriginFromRequest());
    
    [HttpPost("reset-password")]
    [OpenApiOperation("Reset a user's password.", "")]
    [ApiConventionMethod(typeof(NgclopediaApiConventions), nameof(NgclopediaApiConventions.Register))]
    public Task<string> ResetPasswordAsync(ResetPasswordRequestDto request) =>
        _userService.ResetPasswordAsync(request);

    private string GetOriginFromRequest() => 
        $"{Request.Scheme}://{Request.Host.Value}{Request.PathBase.Value}";
}