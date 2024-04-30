using Profiles.Application.Responses;
using Shared.Application.Interfaces;

namespace Profiles.Application.Repositories
{
  public interface ICityRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
  {
    public Task<TEntity> AddAsync(RegisterCityApplicationResponse entity);
    public Task<TEntity> UpdateAsync(Guid id, UpdateCityApplicationResponse entity);
  }
}
