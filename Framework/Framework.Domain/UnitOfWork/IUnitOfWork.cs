using Framework.Domain.Entities;
using Framework.Domain.Repositories;

namespace Framework.Domain.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : class, IBaseEntity;
    Task<int> SaveChangesAsync();
}
