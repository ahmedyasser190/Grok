using ResourceManagement.Application.Common;
using ResourceManagement.Application.Features.Resources;
using ResourceManagement.Domain.Entities;
using ResourceManagement.Domain.Enums;
using IUnitOfWorkContract = ResourceManagement.Domain.Abstractions.IUnitOfWork;

namespace ResourceManagement.Application.Features.Resources.GetResource;

public class GetResourceHandler : IRequestHandler<GetResourceQuery, ResourceResponse?>
{
    private readonly IUnitOfWorkContract _unitOfWork;

    public GetResourceHandler(IUnitOfWorkContract unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResourceResponse?> Handle(GetResourceQuery query, CancellationToken cancellationToken = default)
    {
        var repository = _unitOfWork.GenericRepository<Resource, Guid>();
        var resource = await repository.GetByIdAsync(query.Id, cancellationToken);
        if (resource is null)
            return null;
        return new ResourceResponse(resource.Id,
            resource.UserId,
            resource.FullName,
            resource.ResourceCode,
            resource.Phone,
            resource.HireDate,
            resource.IsActive);
    }
}
