namespace ResourceManagement.Application.Features.Resources.CreateResource;

public record CreateResourceRequest(Guid? UserId,string FullName,string? ResourceCode,string? Phone,DateOnly? HireDate);
