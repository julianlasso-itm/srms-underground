using System.Linq.Expressions;

namespace Shared.Application.Interfaces
{
  public interface IRepository<TEntity>
    where TEntity : class
  {
    public Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);
    public Task<TEntity> GetByIdAsync(Guid id);
    public Task<int> GetCountAsync(string? filter = null, string? filterBy = null);
    public Task<IEnumerable<TEntity>> GetWithPaginationAsync(
      int page,
      int limit,
      string? sort = null,
      string order = "asc",
      string? filter = null,
      string? filterBy = null
    );
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(Guid id, TEntity entity);
    public Task<TEntity> DeleteAsync(Guid id);
  }
}
