using System.Security.Claims;

namespace Ngclopedia.Application.Interfaces.Service.User;

public interface ICurrentUserInitializer
{
    void SetCurrentUser(ClaimsPrincipal user);

    void SetCurrentUserId(string userId);
}