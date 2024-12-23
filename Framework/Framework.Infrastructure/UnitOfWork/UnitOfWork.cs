using Framework.Domain.Entities;
using Framework.Domain.Repositories;
using Framework.Domain.UnitOfWork;
using Framework.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Framework.Infrastructure.UnitOfWork;

public class UnitOfWork(DbContext context) : IUnitOfWork
{
    private readonly Dictionary<Type, object> _repositories = new();

    public IRepository<T> Repository<T>() where T : class, IBaseEntity
    {
        if (_repositories.ContainsKey(typeof(T)))
        {
            return (IRepository<T>)_repositories[typeof(T)];
        }
        var repository = new BaseRepository<T>(context);
        _repositories.Add(typeof(T), repository);

        return repository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }

    public void Dispose() => context.Dispose();
}
