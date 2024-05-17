using AccessControl.Application.Dto;
using AccessControl.Application.Responses;
using Shared.Application.Interfaces;

namespace AccessControl.Application.Repositories
{
  public interface IUserRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
  {
    public Task<string> GetIdByEmail(string email);
    public Task<TEntity> VerifyPassword(string userId, string password);
    public Task<TEntity> UpdatePassword(string userId, string password);
    public Task<UserDataForRecoveryPasswordDto> GetByEmail(string email);
    public Task<TEntity> AddAsync(RegisterUserApplicationResponse entity);
    public Task<TEntity> UpdateAsync(Guid id, UpdateUserApplicationResponse entity);
    public Task<UserDataForSigInDto> GetByEmailAndPassword(string email, string password);
  }
}
