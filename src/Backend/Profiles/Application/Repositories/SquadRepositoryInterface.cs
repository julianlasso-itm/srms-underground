using Profiles.Application.Responses;
using Shared.Application.Interfaces;

namespace Profiles.Application.Repositories
{
  public interface ISquadRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
  {
    public Task<TEntity> AddAsync(RegisterSquadApplicationResponse entity);
    public Task<TEntity> UpdateAsync(Guid id, UpdateSquadApplicationResponse entity);
  }
}
