using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class DeleteRoleHelper
    : BaseHelper,
      IHelper<DeleteRoleDomainRequest, DeleteRoleDomainResponse>
  {
    public static Result<DeleteRoleDomainResponse> Execute(DeleteRoleDomainRequest request)
    {
      var record = GetRoleRecord(request);

      var resultValidation = ValidateRecordFields(record);
      if (resultValidation.IsFailure)
      {
        return Response<DeleteRoleDomainResponse>.Failure(
          resultValidation.Message,
          resultValidation.Code,
          resultValidation.Details
        );
      }

      return Response<DeleteRoleDomainResponse>.Success(MapToResponse(record));
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
