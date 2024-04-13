using AccessControl.Application.Responses;
using Shared.Application.Interfaces;

namespace AccessControl.Application.Repositories;

public interface IUserRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    public Task<TEntity> AddAsync(RegisterUserResponse entity);
    // public Task<TEntity> UpdateAsync(string id, UpdateUserResponse entity);
}
