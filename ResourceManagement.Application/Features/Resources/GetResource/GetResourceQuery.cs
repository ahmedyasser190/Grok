using ResourceManagement.Application.Common;
using ResourceManagement.Application.Features.Resources;

namespace ResourceManagement.Application.Features.Resources.GetResource;

public record GetResourceQuery(Guid Id) : IRequest<ResourceResponse?>;
