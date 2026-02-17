namespace ResourceManagement.Application.Interfaces;

public interface INotificationService
{
    Task SendNotificationAsync(string message, string? userId = null, CancellationToken cancellationToken = default);
}
