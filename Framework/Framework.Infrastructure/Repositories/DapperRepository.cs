using Framework.Domain.Repositories;
using System.Data;
using Dapper;
using Framework.Domain.Entities;

namespace Framework.Infrastructure.Repositories;


public class DapperRepository<T>(IDbConnection connection) : IDapperRepository<T>
    where T : class, IBaseEntity
{
    public async Task<T?> GetByIdAsync(Guid id, string tableName)
    {
        var sql = $"SELECT * FROM {tableName} WHERE Id = @Id";
        return await connection.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
    }

    public async Task<IEnumerable<T>> GetAllAsync(string tableName)
    {
        var sql = $"SELECT * FROM {tableName}";
        return await connection.QueryAsync<T>(sql);
    }

    public async Task<int> AddAsync(T entity, string tableName)
    {
        var sql = GenerateInsertQuery(tableName, entity);
        return await connection.ExecuteAsync(sql, entity);
    }

    public async Task<int> UpdateAsync(T entity, string tableName, string keyColumn)
    {
        var sql = GenerateUpdateQuery(tableName, entity, keyColumn);
        return await connection.ExecuteAsync(sql, entity);
    }

    public async Task<int> DeleteAsync(Guid id, string tableName)
    {
        var sql = $"DELETE FROM {tableName} WHERE Id = @Id";
        return await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<IEnumerable<T>> QueryAsync(string sql, object parameters = null)
    {
        return await connection.QueryAsync<T>(sql, parameters);
    }

    private string GenerateInsertQuery(string tableName, T entity)
    {
        var properties = typeof(T).GetProperties().Where(p => p.Name != "Id").ToList();
        var columns = string.Join(", ", properties.Select(p => p.Name));
        var values = string.Join(", ", properties.Select(p => $"@{p.Name}"));

        return $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
    }

    private string GenerateUpdateQuery(string tableName, T entity, string keyColumn)
    {
        var properties = typeof(T).GetProperties().Where(p => p.Name != keyColumn).ToList();
        var setClause = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));

        return $"UPDATE {tableName} SET {setClause} WHERE {keyColumn} = @{keyColumn}";
    }
}