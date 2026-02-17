using ResourceManagement.Application.Interfaces;

namespace ResourceManagement.Infrastructure.Services;

public class EmailService : IEmailService
{
    public Task SendAsync(string to, string subject, string body, CancellationToken cancellationToken = default)
    {
        // TODO: Integrate with actual email provider (SMTP, SendGrid, etc.)
        return Task.CompletedTask;
    }
}
