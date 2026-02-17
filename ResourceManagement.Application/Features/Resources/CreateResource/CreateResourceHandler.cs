using ResourceManagement.Application.Common;
using ResourceManagement.Application.Features.Resources;
using ResourceManagement.Domain.Entities;
using ResourceManagement.Domain.Enums;
using IUnitOfWorkContract = ResourceManagement.Domain.Abstractions.IUnitOfWork;

namespace ResourceManagement.Application.Features.Resources.CreateResource;

public class CreateResourceHandler : IRequestHandler<CreateResourceCommand, ResourceResponse>
{
    private readonly IUnitOfWorkContract _unitOfWork;

    public CreateResourceHandler(IUnitOfWorkContract unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResourceResponse> Handle(CreateResourceCommand command, CancellationToken cancellationToken = default)
    {
        var repository = _unitOfWork.GenericRepository<Resource, Guid>();
        var resource = new Resource
        {
            Id = Guid.NewGuid(),
            UserId = command.UserId,
            ResourceCode = command.ResourceCode,
            FullName = command.FullName,
            Phone = command.Phone,
            HireDate = command.HireDate,
            IsActive = true,
        };
        await repository.AddAsync(resource, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new ResourceResponse(resource.Id,resource.UserId ,resource.FullName, resource.ResourceCode, resource.Phone,resource.HireDate,
            resource.IsActive);
    }
}
