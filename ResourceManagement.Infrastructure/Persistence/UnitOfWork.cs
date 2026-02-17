using Microsoft.Extensions.DependencyInjection;
using ResourceManagement.Domain.Abstractions;
using ResourceManagement.Domain.Abstractions.IRepositories;
using ResourceManagement.Domain.Entities;

namespace ResourceManagement.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(ApplicationDbContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public IRepository<TEntity, TKey> GenericRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey> where TKey : struct
    {
        var type = typeof(TEntity);
        if (_repositories.TryGetValue(type, out var repo))
            return (IRepository<TEntity, TKey>)repo;

        var repositoryInstance = Activator.CreateInstance(
            typeof(Repositories.Repository<,>).MakeGenericType(type, typeof(TKey)),
            _context);

        if (repositoryInstance is null)
            throw new InvalidOperationException($"Failed to create repository for {type.Name}.");

        var repository = (IRepository<TEntity, TKey>)repositoryInstance;
        _repositories[type] = repository;
        return repository;
    }

    public TRepository CustomRepository<TRepository>() where TRepository : class
    {
        return _serviceProvider.GetRequiredService<TRepository>();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
