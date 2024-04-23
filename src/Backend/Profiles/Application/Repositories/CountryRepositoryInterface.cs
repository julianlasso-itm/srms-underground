using Profiles.Application.Responses;
using Shared.Application.Interfaces;

namespace Profiles.Application.Repositories;

public interface ICountryRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    public Task<TEntity> AddAsync(RegisterCountryApplicationResponse entity);
    public Task<TEntity> UpdateAsync(Guid id, UpdateCountryApplicationResponse entity);
}
