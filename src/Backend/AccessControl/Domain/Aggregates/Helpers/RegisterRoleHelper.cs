using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.ValueObjects;
using Shared.Common;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class RegisterRoleHelper
    : BaseHelper,
      IHelper<RegisterRoleDomainRequest, RegisterRoleDomainResponse>
  {
    public static Result<RegisterRoleDomainResponse> Execute(RegisterRoleDomainRequest request)
    {
      var record = GetRoleRecord(request);
      var resultValidation = ValidateRecordFields(record);

      if (resultValidation.IsFailure)
      {
        return Response<RegisterRoleDomainResponse>.Failure(
          resultValidation.Message,
          resultValidation.Code,
          resultValidation.Details
        );
      }

      var role = new RoleEntity();
      role.Register(record.Name, record.Description);

      return Response<RegisterRoleDomainResponse>.Success(MapToResponse(role));
    }

    private static RoleRecord GetRoleRecord(RegisterRoleDomainRequest request)
    {
      var name = new NameValueObject(request.Name);
      var description =
        request.Description != null ? new DescriptionValueObject(request.Description) : null;

      return new RoleRecord { Name = name, Description = description };
    }

    private static RegisterRoleDomainResponse MapToResponse(RoleEntity role)
    {
      return new RegisterRoleDomainResponse
      {
        RoleId = role.RoleId.Value,
        Name = role.Name.Value,
        Description = role.Description?.Value,
        Disabled = role.Disabled.Value,
      };
    }
  }
}
