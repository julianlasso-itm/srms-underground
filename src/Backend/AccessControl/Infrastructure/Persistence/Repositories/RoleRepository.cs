using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Repositories;

namespace AccessControl.Infrastructure.Persistence.Repositories;

public class RoleRepository : BaseRepository<Role>, IRoleRepository<Role>
{
    public RoleRepository(DbContext context)
        : base(context) { }

    public Role MapToEntity(RegisterRoleResponse response)
    {
        var entity = new Role
        {
            RoleId = Guid.Parse(response.RoleId),
            Name = response.Name,
            Description = response.Description,
            Disabled = response.Disabled,
        };
        return entity;
    }
}
