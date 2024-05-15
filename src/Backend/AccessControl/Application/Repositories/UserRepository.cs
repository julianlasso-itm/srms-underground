using AccessControl.Application.Responses;
using AccessControlApplication.Dto;
using Shared.Application.Interfaces;

namespace AccessControl.Application.Repositories
{
  public interface IUserRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
  {
    public Task<TEntity> AddAsync(RegisterUserApplicationResponse entity);
    public Task<TEntity> UpdateAsync(Guid id, UpdateUserApplicationResponse entity);
    public Task<UserDataForSigInDto> GetByEmailAndPassword(string email, string password);
  }
}
