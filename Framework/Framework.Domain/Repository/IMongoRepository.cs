using Framework.Domain.Entities;

namespace Framework.Domain.Repository;

public interface IMongoRepository<TEntity> where TEntity : BaseEntity
{
    Task DeleteAsync(Guid id);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);

}