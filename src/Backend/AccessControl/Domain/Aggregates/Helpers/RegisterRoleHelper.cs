using AccessControl.Domain.Aggregates.Dto;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers;

internal abstract class RegisterRoleHelper : BaseHelper, IHelper<RegisterRole, RegisterRoleResponse>
{
    public static RegisterRoleResponse Execute(RegisterRole registerData)
    {
        var data = GetRoleStruct(registerData);
        ValidateStructureFields(data);

        var role = new RoleEntity();
        role.Register(data.Name, data.Description);

        return new RegisterRoleResponse
        {
            RoleId = role.RoleId.Value,
            Name = role.Name.Value,
            Description = role.Description?.Value,
            Disabled = role.IsDisabled.Value,
        };
    }

    private static RoleStruct GetRoleStruct(RegisterRole registerData)
    {
        var name = new NameValueObject(registerData.Name);
        var description =
            registerData.Description != null
                ? new DescriptionValueObject(registerData.Description)
                : null;

        return new RoleStruct { Name = name, Description = description };
    }
}
