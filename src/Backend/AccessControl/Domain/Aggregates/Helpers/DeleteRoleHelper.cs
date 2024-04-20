using AccessControl.Domain.Aggregates.Dto;
using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers;

internal abstract class DeleteRoleHelper : BaseHelper, IHelper<DeleteRole, DeleteRole>
{
    public static DeleteRole Execute(DeleteRole data)
    {
        var @struct = GetRoleStruct(data);
        ValidateStructureFields(@struct);
        return data;
    }

    private static RoleStruct GetRoleStruct(DeleteRole data)
    {
        var id = new RoleIdValueObject(data.RoleId);
        return new RoleStruct { RoleId = id };
    }
}
