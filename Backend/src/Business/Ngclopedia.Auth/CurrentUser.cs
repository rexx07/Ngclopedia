using System.Security.Claims;
using Ngclopedia.Application.Authorization;
using Ngclopedia.Application.Interfaces.Common;
using Ngclopedia.Application.Interfaces.Service.User;

namespace Ngclopedia.Auth;

public class CurrentUser : ICurrentUser, ICurrentUserInitializer
{
    private ClaimsPrincipal? _user;

    private Guid _userId = Guid.Empty;

    public bool IsActive { get; private set; }

    public string? Name => _user?.Identity?.Name;

    public DateTime ValidUpto { get; private set; }

    public Guid GetUserId()
    {
        return IsAuthenticated()
            ? Guid.Parse(_user?.GetUserId() ?? Guid.Empty.ToString())
            : _userId;
    }

    public string? GetUserEmail()
    {
        return IsAuthenticated()
            ? _user!.GetEmail()
            : string.Empty;
    }

    public bool IsAuthenticated()
    {
        return _user?.Identity?.IsAuthenticated is true;
    }

    public bool IsInRole(string role)
    {
        return _user?.IsInRole(role) is true;
    }

    public IEnumerable<Claim>? GetUserClaims()
    {
        return _user?.Claims;
    }

    public void SetCurrentUser(ClaimsPrincipal user)
    {
        if (_user != null) throw new Exception("Method reserved for in-scope initialization");

        _user = user;
    }

    public void SetCurrentUserId(string userId)
    {
        if (_userId != Guid.Empty) throw new Exception("Method reserved for in-scope initialization");

        if (!string.IsNullOrEmpty(userId)) _userId = Guid.Parse(userId);
    }

    public void AddValidity(int months)
    {
        ValidUpto = ValidUpto.AddMonths(months);
    }

    public void SetValidity(in DateTime validTill)
    {
        ValidUpto = ValidUpto < validTill
            ? validTill
            : throw new Exception("Subscription cannot be backdated.");
    }

    public void Activate()
    {
        if (!IsInRole(NgclopediaRoles.Superuser) || !IsInRole(NgclopediaRoles.Admin))
            throw new InvalidOperationException("Account not Qualified");

        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}