using System.Linq.Expressions;
using Framework.Domain.Entities;

namespace Framework.Domain.Repositories;

public interface IRepository<T> where T : class, IBaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllIncludingDeletedAsync();
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task DeletePermanentlyAsync(Guid id);
    Task RestoreAsync(Guid id);
    Task DeleteRangeAsync(IEnumerable<T> entities);
    Task<bool> ExistsAsync(Guid id);
    Task<int> CountAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    IQueryable<T> AsQueryable();
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    Task SaveChangesAsync();

}