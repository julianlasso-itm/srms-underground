using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class DeleteRoleHelper
    : BaseHelper,
      IHelper<DeleteRoleDomainRequest, DeleteRoleDomainResponse>
  {
    public static DeleteRoleDomainResponse Execute(DeleteRoleDomainRequest request)
    {
      var @struct = GetRoleStruct(request);
      ValidateStructureFields(@struct);
      return MapToResponse(@struct);
    }

    private static RoleStruct GetRoleStruct(DeleteRoleDomainRequest request)
    {
      var id = new RoleIdValueObject(request.RoleId);
      return new RoleStruct { RoleId = id };
    }

    private static DeleteRoleDomainResponse MapToResponse(RoleStruct role)
    {
      return new DeleteRoleDomainResponse { RoleId = role.RoleId.Value };
    }
  }
}
