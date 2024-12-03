using Framework.Domain.Entities;
using System.Linq.Expressions;

namespace Framework.Domain.Repository;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetAsync(Guid id);
    Task<TEntity?> GetTrackingAsync(Guid id);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
    bool Exists(Expression<Func<TEntity, bool>> expression);
    TEntity? Get(Guid id);
    Task AddAsync(TEntity entity);
    void Add(TEntity entity);
    Task AddRangeAsync(ICollection<TEntity> entities);
    void Update(TEntity entity);
    Task<int> SaveAsync();
    void SaveSync();

}
