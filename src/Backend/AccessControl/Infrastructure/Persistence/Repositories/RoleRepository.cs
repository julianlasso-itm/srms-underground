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

    public Task<Role> AddAsync(RegisterRoleResponse entity)
    {
        var role = new Role
        {
            RoleId = Guid.Parse(entity.RoleId),
            Name = entity.Name,
            Description = entity.Description,
            Disabled = entity.Disabled,
        };
        return AddAsync(role);
    }

    public Task<Role> UpdateAsync(string id, UpdateRoleResponse entity)
    {
        var role = new Role { RoleId = Guid.Parse(entity.RoleId) };
        if (entity.Name != null) role.Name = entity.Name;
        if (entity.Description != null) role.Description = entity.Description;
        if (entity.Disabled != null) role.Disabled = (bool)entity.Disabled;
        return UpdateAsync(entity.RoleId, role);
    }
}
