using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Repositories;

namespace AccessControl.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<UserModel>, IUserRepository<UserModel>
{
    public UserRepository(DbContext context)
        : base(context) { }

    public Task<UserModel> AddAsync(RegisterUserApplicationResponse entity)
    {
        var user = new UserModel
        {
            UserId = Guid.Parse(entity.UserId),
            Email = entity.Email,
            Password = entity.Password,
            Disabled = entity.Disabled,
        };
        return AddAsync(user);
    }
}
