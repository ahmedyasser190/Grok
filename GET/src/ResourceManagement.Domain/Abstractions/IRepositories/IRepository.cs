using ResourceManagement.Domain.Shared;

namespace ResourceManagement.Domain.Abstractions.IRepositories;

public interface IRepository<TEntity, TKey> where TEntity : class where TKey : struct
{
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PagedResult<TEntity>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<bool> ExistsAsync(TKey id, CancellationToken cancellationToken = default);
}
