using ResourceManagement.Domain.Entities;

namespace ResourceManagement.Domain.Abstractions.IRepositories;

public interface IResourceRepository : IRepository<Resource, Guid>
{
}
