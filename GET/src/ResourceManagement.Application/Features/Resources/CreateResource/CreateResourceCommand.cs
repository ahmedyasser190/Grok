using ResourceManagement.Application.Common;
using ResourceManagement.Application.Features.Resources;

namespace ResourceManagement.Application.Features.Resources.CreateResource;

public record CreateResourceCommand(Guid UserId, string? FullName, string? ResourceCode,
    string? Phone,DateOnly? HireDate) : IRequest<ResourceResponse>;
