using Framework.Domain.Entities;
using Framework.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Framework.Infrastructure.Repositories;

public class BaseRepository<T>(DbContext context) : IRepository<T> where T : class, IBaseEntity
{
    private readonly DbContext Context = context;
    private readonly DbSet<T> DbSet = context.Set<T>();

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await DbSet.FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.Where(e => !e.IsDeleted).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllIncludingDeletedAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await DbSet.AddRangeAsync(entities);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            entity.IsDeleted = true;
            DbSet.Update(entity);
            await Context.SaveChangesAsync();
        }
    }

    public async Task DeletePermanentlyAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }

    public async Task RestoreAsync(Guid id)
    {
        var entity = await DbSet.FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted);
        if (entity != null)
        {
            entity.IsDeleted = false;
            DbSet.Update(entity);
            await Context.SaveChangesAsync();
        }
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        var baseEntities = entities.ToList();
        foreach (var entity in baseEntities)
        {
            entity.IsDeleted = true;
        }

        DbSet.UpdateRange(baseEntities);
        await Context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await DbSet.AnyAsync(e => e.Id == id && !e.IsDeleted);
    }

    public async Task<int> CountAsync()
    {
        return await DbSet.CountAsync(e => !e.IsDeleted);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await DbSet.Where(predicate).Where(e => !e.IsDeleted).ToListAsync();
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await DbSet.Where(predicate).Where(e => !e.IsDeleted).FirstOrDefaultAsync();
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }

    public IQueryable<T> AsQueryable()
    {
        return DbSet.Where(e => !e.IsDeleted).AsQueryable();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
    {
        return DbSet.Where(predicate).Where(e => !e.IsDeleted);
    }
}