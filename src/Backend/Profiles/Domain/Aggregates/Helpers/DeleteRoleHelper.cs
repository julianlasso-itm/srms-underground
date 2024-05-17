using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Records;
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
      var record = GetRoleRecord(request);
      ValidateRecordFields(record);
      return new DeleteRoleDomainResponse { RoleId = record.RoleId.Value };
    }

    private static RoleRecord GetRoleRecord(DeleteRoleDomainRequest request)
    {
      var id = new RoleIdValueObject(request.RoleId);
      return new RoleRecord { RoleId = id };
    }
  }
}
