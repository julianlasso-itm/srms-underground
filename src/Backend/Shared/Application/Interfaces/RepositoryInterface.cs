namespace Shared.Application.Interfaces;

public interface IRepository<TEntity>
    where TEntity : class
{
    public Task<TEntity> GetByIdAsync(Guid id);
    public Task<int> GetCountAsync(string? filter = null);
    public Task<IEnumerable<TEntity>> GetWithPaginationAsync(
        int page,
        int limit,
        string sort = "CreatedAt",
        string order = "asc",
        string? filter = null
    );
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(Guid id, TEntity entity);
    public Task<TEntity> DeleteAsync(Guid id);
    public Task<TEntity> SoftDeleteAsync(Guid id);
}
