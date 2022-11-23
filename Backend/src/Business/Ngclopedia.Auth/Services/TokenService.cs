using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ngclopedia.Application.Authorization;
using Ngclopedia.Application.DataTransferObjects.Auth.Token;
using Ngclopedia.Application.Exceptions;
using Ngclopedia.Application.Interfaces.Common;
using Ngclopedia.Application.Interfaces.Service.Auth;
using Ngclopedia.Auth.Jwt;
using Ngclopedia.Domain.Users;
using Ngclopedia.Infrastructure.SecurityHeaders;

namespace Ngclopedia.Auth.Services;

internal class TokenService : ITokenService
{
    private readonly ICurrentUser _currentUser;
    private readonly JwtSettings _jwtSettings;
    private readonly SecuritySettings _securitySettings;
    private readonly IStringLocalizer _t;
    private readonly UserManager<ApplicationUser> _userManager;

    public TokenService(
        UserManager<ApplicationUser> userManager,
        IOptions<JwtSettings> jwtSettings,
        IStringLocalizer<TokenService> localizer,
        IOptions<SecuritySettings> securitySettings,
        ICurrentUser currentUser)
    {
        _userManager = userManager;
        _t = localizer;
        _jwtSettings = jwtSettings.Value;
        _securitySettings = securitySettings.Value;
        _currentUser = currentUser;
    }

    public async Task<TokenDto> GetTokenAsync(TokenRequestDto request, string ipAddress,
        CancellationToken cancellationToken)
    {
        if (await _userManager.FindByEmailAsync(request.Email.Trim().Normalize()) is not { } user
            || !await _userManager.CheckPasswordAsync(user, request.Password))
            throw new UnauthorizedException(_t["Authentication Failed."]);

        if (!user.IsActive) throw new UnauthorizedException(_t["User Not Active. Please contact the administrator."]);

        if (_securitySettings.RequireConfirmedAccount && !user.EmailConfirmed)
            throw new UnauthorizedException(_t["E-Mail not confirmed."]);

        if (_currentUser.IsInRole(NgclopediaRoles.Admin) || _currentUser.IsInRole(NgclopediaRoles.Superuser))
            if (DateTime.UtcNow > _currentUser.ValidUpto)
                throw new UnauthorizedException(
                    _t["Root User Validity Has Expired. Please contact the Application Administrator."]);

        return await GenerateTokensAndUpdateUser(user, ipAddress);
    }

    public async Task<TokenDto> RefreshTokenAsync(RefreshTokenRequestDto request, string ipAddress)
    {
        var userPrincipal = GetPrincipalFromExpiredToken(request.Token);
        var userEmail = userPrincipal.GetEmail();
        var user = await _userManager.FindByEmailAsync(userEmail);
        if (user is null) throw new UnauthorizedException(_t["Authentication Failed."]);

        if (user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            throw new UnauthorizedException(_t["Invalid Refresh Token."]);

        return await GenerateTokensAndUpdateUser(user, ipAddress);
    }

    private async Task<TokenDto> GenerateTokensAndUpdateUser(ApplicationUser user, string ipAddress)
    {
        var token = GenerateJwt(user, ipAddress);

        user.RefreshToken = GenerateRefreshToken();
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationInDays);

        await _userManager.UpdateAsync(user);

        return new TokenDto(token, user.RefreshToken, user.RefreshTokenExpiryTime);
    }

    private string GenerateJwt(ApplicationUser user, string ipAddress)
    {
        return GenerateEncryptedToken(GetSigningCredentials(), GetClaims(user, ipAddress));
    }

    private IEnumerable<Claim> GetClaims(ApplicationUser user, string ipAddress)
    {
        return new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Email, user.Email),
            new(NgclopediaClaims.Fullname, $"{user.FirstName} {user.LastName}"),
            new(ClaimTypes.Name, user.FirstName ?? string.Empty),
            new(ClaimTypes.Surname, user.LastName ?? string.Empty),
            new(NgclopediaClaims.IpAddress, ipAddress),
            new(NgclopediaClaims.ImageUrl, user.ImageUrl ?? string.Empty),
            new(ClaimTypes.MobilePhone, user.PhoneNumber ?? string.Empty)
        };
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private string GenerateEncryptedToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
    {
        var token = new JwtSecurityToken(
            "nbhh",
            "ghunb",
            claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes),
            signingCredentials: signingCredentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
            ValidateIssuer = false,
            ValidateAudience = false,
            RoleClaimType = ClaimTypes.Role,
            ClockSkew = TimeSpan.Zero,
            ValidateLifetime = false
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            throw new UnauthorizedException(_t["Invalid Token."]);

        return principal;
    }

    private SigningCredentials GetSigningCredentials()
    {
        var secret = Encoding.UTF8.GetBytes(_jwtSettings.Key);
        return new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256);
    }
}