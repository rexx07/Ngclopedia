using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Ngclopedia.Application.Exceptions;
using Ngclopedia.Application.Interfaces.Common;

namespace Ngclopedia.Infrastructure.Notifications;

[Authorize]
public class NotificationHub : Hub, ITransientService
{
    private readonly ICurrentUser? _currentUser;
    private readonly ILogger<NotificationHub> _logger;

    public NotificationHub(ICurrentUser? currentUser, ILogger<NotificationHub> logger)
    {
        _currentUser = currentUser;
        _logger = logger;
    }

    public override async Task OnConnectedAsync()
    {
        if (_currentUser is null) throw new UnauthorizedException("Authentication Failed.");

        await Groups.AddToGroupAsync(Context.ConnectionId, $"GroupTenant-{_currentUser.GetUserId()}");

        await base.OnConnectedAsync();

        _logger.LogInformation("A client connected to NotificationHub: {connectionId}", Context.ConnectionId);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"GroupTenant-{_currentUser!.GetUserId()}");

        await base.OnDisconnectedAsync(exception);

        _logger.LogInformation("A client disconnected from NotificationHub: {connectionId}", Context.ConnectionId);
    }
}