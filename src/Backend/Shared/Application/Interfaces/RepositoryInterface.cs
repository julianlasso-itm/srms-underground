namespace Shared.Application.Interfaces;

public interface IRepository<TEntity>
    where TEntity : class
{
    Task<TEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(Guid id, TEntity entity);
    Task<TEntity> DeleteAsync(Guid id);
}
