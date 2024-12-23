using Framework.Domain.Entities;

namespace Framework.Domain.Repositories;

public interface IDapperRepository<T> where T : class, IBaseEntity
{
    Task<T?> GetByIdAsync(Guid id, string tableName);
    Task<IEnumerable<T>> GetAllAsync(string tableName);
    Task<int> AddAsync(T entity, string tableName);
    Task<int> UpdateAsync(T entity, string tableName, string keyColumn);
    Task<int> DeleteAsync(Guid id, string tableName);
    Task<IEnumerable<T>> QueryAsync(string sql, object parameters = null);
}