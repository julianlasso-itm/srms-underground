using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Common;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class DeleteRoleHelper
    : BaseHelper,
      IHelper<DeleteRoleDomainRequest, DeleteRoleDomainResponse>
  {
    public static Result<DeleteRoleDomainResponse> Execute(DeleteRoleDomainRequest request)
    {
      var record = GetRoleRecord(request);
      var response = ValidateRecordFields(record);

      if (response.IsFailure)
      {
        return Response<DeleteRoleDomainResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<DeleteRoleDomainResponse>.Success(
        new DeleteRoleDomainResponse { RoleId = record.RoleId.Value }
      );
    }

    private static RoleRecord GetRoleRecord(DeleteRoleDomainRequest request)
    {
      var id = new RoleIdValueObject(request.RoleId);
      return new RoleRecord { RoleId = id };
    }
  }
}
