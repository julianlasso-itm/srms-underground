using QueryBank.Application.Responses;
using Shared.Application.Interfaces;

namespace QueryBank.Application.Repositories
{
  public interface ISkillRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
  {
    public Task<TEntity> AddAsync(RegisterSkillApplicationResponse entity);
    public Task<TEntity> UpdateAsync(Guid id, UpdateSkillApplicationResponse entity);
  }
}
