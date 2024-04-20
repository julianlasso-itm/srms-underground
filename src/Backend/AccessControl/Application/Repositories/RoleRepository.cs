using AccessControl.Application.Responses;
using Shared.Application.Interfaces;

namespace AccessControl.Application.Repositories;

public interface IRoleRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    public Task<TEntity> AddAsync(RegisterRoleApplicationResponse entity);
    public Task<TEntity> UpdateAsync(Guid id, UpdateRoleApplicationResponse entity);
}
