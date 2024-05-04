using Profiles.Application.Responses;
using Shared.Application.Interfaces;

namespace Profiles.Application.Repositories
{
  public interface ILevelRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
  {
    public Task<TEntity> AddAsync(RegisterLevelApplicationResponse entity);
    public Task<TEntity> UpdateAsync(Guid id, UpdateLevelApplicationResponse entity);
  }
}
