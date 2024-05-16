using System.Linq.Expressions;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Persistence.Models;
using AccessControlApplication.Dto;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Repositories;

namespace AccessControl.Infrastructure.Persistence.Repositories
{
  public class UserRepository : BaseRepository<UserModel>, IUserRepository<UserModel>
  {
    public UserRepository(ApplicationDbContext context)
      : base(context) { }

    public Task<UserModel> AddAsync(RegisterUserApplicationResponse entity)
    {
      var user = new UserModel
      {
        UserId = Guid.Parse(entity.UserId),
        Name = entity.Name,
        Email = entity.Email,
        Password = entity.Password,
        Photo = entity.Photo,
        Disabled = entity.Disabled,
        CreatedAt = DateTime.UtcNow,
        UserPerRoles = new List<UserPerRoleModel>(
          entity.Roles.Select(role => new UserPerRoleModel
          {
            UserPerRoleId = Guid.NewGuid(),
            UserId = Guid.Parse(entity.UserId),
            RoleId = Guid.Parse(role)
          })
        )
      };
      return AddAsync(user);
    }

    public async Task<UserDataForSigInDto> GetByEmailAndPassword(string email, string password)
    {
      Expression<Func<UserModel, bool>> expression = user =>
        user.Email == email
        && user.Password == password
        && !user.Disabled
        && user.DeletedAt == null;

      var data =
        await Context
          .Set<UserModel>()
          .Include(user => user.UserPerRoles)
          .ThenInclude(userPerRole => userPerRole.Role)
          .FirstOrDefaultAsync(expression)
        ?? throw new Exception("User not found or credentials incorrect.");

      data.UserPerRoles = data
        .UserPerRoles.Where(role => !role.Role.Disabled && role.Role.DeletedAt == null)
        .ToList();

      return new UserDataForSigInDto
      {
        UserId = data.UserId.ToString(),
        Name = data.Name,
        Photo = data.Photo,
        Roles = data.UserPerRoles.Select(role => role.Role.Name).ToList()
      };
    }

    public async Task<string> GetIdByEmail(string email)
    {
      Expression<Func<UserModel, bool>> expression = user =>
        user.Email == email && !user.Disabled && user.DeletedAt == null;
      var data = await GetFirstAsync(expression);
      return data.UserId.ToString();
    }

    public Task<UserModel> UpdateAsync(Guid id, UpdateUserApplicationResponse entity)
    {
      var user = new UserModel { UserId = id };
      if (entity.Email != null)
      {
        user.Email = entity.Email;
      }
      if (entity.Password != null)
      {
        user.Password = entity.Password;
      }
      if (entity.Disabled != null)
      {
        user.Disabled = (bool)entity.Disabled;
      }
      return UpdateAsync(id, user);
    }
  }
}
