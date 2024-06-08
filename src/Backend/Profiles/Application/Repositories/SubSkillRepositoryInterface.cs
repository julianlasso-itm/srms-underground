using Profiles.Application.Responses;
using Shared.Application.Interfaces;

namespace Profiles.Application.Repositories
{
  public interface ISubSkillRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
  {
    public Task<TEntity> AddAsync(RegisterSubSkillApplicationResponse entity);
    public Task<TEntity> UpdateAsync(Guid id, UpdateSubSkillApplicationResponse entity);
  }
}
