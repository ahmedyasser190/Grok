using ResourceManagement.Domain.Abstractions.IRepositories;
using ResourceManagement.Domain.Entities;

namespace ResourceManagement.Domain.Abstractions;

public interface IUnitOfWork
{
    IRepository<TEntity, TKey> GenericRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey> where TKey : struct;
    TRepository CustomRepository<TRepository>() where TRepository : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
