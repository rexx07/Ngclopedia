using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ngclopedia.Application.DataTransferObjects.Auth.Token;
using Ngclopedia.Application.Interfaces.Service.Auth;
using NSwag.Annotations;

namespace Ngclopedia.WebApi.Controllers.Identity;

public sealed class TokensController: VersionNeutralApiController
{
    private readonly ITokenService _tokenService;

    public TokensController(ITokenService tokenService) =>
        _tokenService = tokenService;

    [HttpPost]
    [AllowAnonymous]
    [OpenApiOperation("Request an access token using credentials.", "")]
    public Task<TokenDto> GetTokenAsync(TokenRequestDto request, CancellationToken cancellationToken) =>
        _tokenService.GetTokenAsync(request, GetIpAddress(), cancellationToken);

    [HttpPost]
    [AllowAnonymous]
    [OpenApiOperation("Request an access toekn using a refresh token.", "")]
    [ApiConventionMethod(typeof(NgclopediaApiConventions), nameof(NgclopediaApiConventions.Search))]
    public Task<TokenDto> RefreshAsync(RefreshTokenRequestDto request) =>
        _tokenService.RefreshTokenAsync(request, GetIpAddress());

    private string GetIpAddress() =>
        Request.Headers.ContainsKey("X-Forwarded-For")
            ? Request.Headers["X-Forwarded-For"]
            : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? "N/A";
}