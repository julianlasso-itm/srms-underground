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

    public User MapToEntity(RegisterUserResponse response)
    {
        var entity = new User
        {
            UserId = Guid.Parse(response.UserId),
            Email = response.Email,
            Password = response.Password,
            Disabled = response.Disabled,
        };
        return entity;
    }
}
