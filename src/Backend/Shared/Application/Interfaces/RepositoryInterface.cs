namespace Shared.Application.Interfaces;

public interface IRepository<TEntity>
    where TEntity : class
{
    public Task<TEntity> GetByIdAsync(Guid id);
    public Task<IEnumerable<TEntity>> GetAllAsync();
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(Guid id, TEntity entity);
    public Task<TEntity> DeleteAsync(Guid id);
}
