using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Persistence.Models;
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
