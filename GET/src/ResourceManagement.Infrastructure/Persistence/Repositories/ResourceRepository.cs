using ResourceManagement.Domain.Abstractions.IRepositories;
using ResourceManagement.Domain.Entities;

namespace ResourceManagement.Infrastructure.Persistence.Repositories;

public class ResourceRepository : Repository<Resource, Guid>, IResourceRepository
{
    public ResourceRepository(ApplicationDbContext context) : base(context)
    {
    }
}
