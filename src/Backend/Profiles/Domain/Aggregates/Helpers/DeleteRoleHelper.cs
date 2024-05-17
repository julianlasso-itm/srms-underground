using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class DeleteRoleHelper
    : BaseHelper,
      IHelper<DeleteRoleDomainRequest, DeleteRoleDomainResponse>
  {
    public static DeleteRoleDomainResponse Execute(DeleteRoleDomainRequest request)
    {
      var @struct = GetRoleStruct(request);
      ValidateStructureFields(@struct);
      return new DeleteRoleDomainResponse { RoleId = @struct.RoleId.Value };
    }

    private static RoleStruct GetRoleStruct(DeleteRoleDomainRequest request)
    {
      var id = new RoleIdValueObject(request.RoleId);
      return new RoleStruct { RoleId = id };
    }
  }
}
