using AccessControl.Domain.Aggregates.Dto.Request;
using AccessControl.Domain.Aggregates.Dto.Response;
using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers;

internal abstract class DeleteRoleHelper
    : BaseHelper,
        IHelper<DeleteRoleDomainRequest, DeleteRoleDomainResponse>
{
    public static DeleteRoleDomainResponse Execute(DeleteRoleDomainRequest data)
    {
        var @struct = GetRoleStruct(data);
        ValidateStructureFields(@struct);
        return new DeleteRoleDomainResponse { RoleId = @struct.RoleId.Value };
    }

    private static RoleStruct GetRoleStruct(DeleteRoleDomainRequest data)
    {
        var id = new RoleIdValueObject(data.RoleId);
        return new RoleStruct { RoleId = id };
    }
}
