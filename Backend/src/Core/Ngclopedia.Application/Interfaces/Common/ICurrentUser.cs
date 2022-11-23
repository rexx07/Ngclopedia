using System.Security.Claims;

namespace Ngclopedia.Application.Interfaces.Common;

public interface ICurrentUser
{
    string? Name { get; }
    DateTime ValidUpto { get; }

    Guid GetUserId();

    string? GetUserEmail();

    bool IsAuthenticated();
    bool IsInRole(string role);

    IEnumerable<Claim>? GetUserClaims();
}