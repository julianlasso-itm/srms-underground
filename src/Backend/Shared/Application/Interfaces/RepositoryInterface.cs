namespace Shared.Application.Interfaces;

public interface IRepository<TEntity>
    where TEntity : class
{
    public Task<TEntity> GetByIdAsync(string id);
    public Task<IEnumerable<TEntity>> GetAllAsync();
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(string id, TEntity entity);
    public Task<TEntity> DeleteAsync(string id);
}
