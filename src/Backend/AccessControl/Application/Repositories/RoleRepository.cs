using AccessControl.Application.Responses;
using Shared.Application.Interfaces;

namespace AccessControl.Application.Repositories;

public interface IRoleRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    public Task<TEntity> AddAsync(RegisterRoleResponse entity);
    public Task<TEntity> UpdateAsync(string id, UpdateRoleResponse entity);
}
