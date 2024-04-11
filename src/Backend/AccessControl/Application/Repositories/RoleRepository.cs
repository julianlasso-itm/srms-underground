using AccessControl.Application.Responses;
using Shared.Application.Interfaces;

namespace AccessControl.Application.Repositories;

public interface IRoleRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    TEntity MapToEntity(RegisterRoleResponse response);
}
