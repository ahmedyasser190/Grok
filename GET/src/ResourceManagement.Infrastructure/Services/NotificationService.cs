using ResourceManagement.Application.Interfaces;

namespace ResourceManagement.Infrastructure.Services;

public class NotificationService : INotificationService
{
    public Task SendNotificationAsync(string message, string? userId = null, CancellationToken cancellationToken = default)
    {
        // TODO: Integrate with actual notification channel (push, in-app, etc.)
        return Task.CompletedTask;
    }
}
