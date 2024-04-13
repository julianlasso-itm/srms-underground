using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Repositories;

namespace AccessControl.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository<User>
{
    public UserRepository(DbContext context)
        : base(context) { }

    public Task<User> AddAsync(RegisterUserResponse entity)
    {
        var user = new User
        {
            UserId = Guid.Parse(entity.UserId),
            Email = entity.Email,
            Password = entity.Password,
            Disabled = entity.Disabled,
        };
        return AddAsync(user);
    }
}
