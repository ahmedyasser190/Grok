using ResourceManagement.Domain.Enums;

namespace ResourceManagement.Application.Features.Resources;

public record ResourceResponse(Guid Id, Guid UserId, string FullName, string? ResourceCode, string? Phone, DateOnly? HireDate,
     bool? IsActive);
