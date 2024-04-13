using AccessControl.Domain.Aggregates.Dto;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers;

internal abstract class UpdateRoleHelper : BaseHelper, IHelper<UpdateRole, UpdateRoleResponse>
{
    public static UpdateRoleResponse Execute(UpdateRole data)
    {
        var @struct = GetRoleStruct(data);
        var role = new RoleEntity(@struct);
        var response = new UpdateRoleResponse { RoleId = role.RoleId.Value };

        if (data.Name != null)
        {
            var name = new NameValueObject(data.Name);
            role.UpdateName(name);
            response.Name = role.Name.Value;
        }

        if (data.Description != null)
        {
            var description = new DescriptionValueObject(data.Description);
            role.UpdateDescription(description);
            response.Description = role.Description.Value;
        }

        if (data.Disable != null)
        {
            if (data.Disable == true)
            {
                role.Disable();
            }
            else
            {
                role.Enable();
            }
            response.Disabled = role.IsDisabled.Value;
        }

        return response;
    }

    private static RoleStruct GetRoleStruct(UpdateRole data)
    {
        var id = new RoleIdValueObject(data.RoleId);
        return new RoleStruct { RoleId = id };
    }
}
