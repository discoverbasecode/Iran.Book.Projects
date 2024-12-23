using System.Linq.Expressions;
using Framework.Domain.Entities;

namespace Framework.Domain.Repositories;

public interface IMongoRepository<T> where T : IBaseEntity
{
    Task<T> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(string id, T entity);
    Task DeleteAsync(string id);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
}