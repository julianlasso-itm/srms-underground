using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Records;
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
      var record = GetRoleRecord(request);
      ValidateRecordFields(record);
      return MapToResponse(record);
    }

    private static RoleRecord GetRoleRecord(DeleteRoleDomainRequest request)
    {
      var id = new RoleIdValueObject(request.RoleId);
      return new RoleRecord { RoleId = id };
    }

    private static DeleteRoleDomainResponse MapToResponse(RoleRecord role)
    {
      return new DeleteRoleDomainResponse { RoleId = role.RoleId.Value };
    }
  }
}
