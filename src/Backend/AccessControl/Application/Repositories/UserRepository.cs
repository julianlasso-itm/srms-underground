using AccessControl.Application.Responses;
using Shared.Application.Interfaces;

namespace AccessControl.Application.Repositories;

public interface IUserRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    TEntity MapToEntity(RegisterUserResponse response);
}
