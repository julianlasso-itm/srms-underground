using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class RegisterRoleHelper
    : BaseHelper,
      IHelper<RegisterRoleDomainRequest, RegisterRoleDomainResponse>
  {
    public static Result<RegisterRoleDomainResponse> Execute(RegisterRoleDomainRequest request)
    {
      var record = GetRoleRecord(request);
      var response = ValidateRecordFields(record);

      if (response.IsFailure)
      {
        return Response<RegisterRoleDomainResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var role = new RoleEntity();
      role.Register(record.Name, record.Description);

      return Response<RegisterRoleDomainResponse>.Success(MapToResponse(role, request));
    }

    private static RoleRecord GetRoleRecord(RegisterRoleDomainRequest request)
    {
      var name = new NameValueObject(request.Name);
      var description =
        request.Description != null ? new DescriptionValueObject(request.Description) : null;

      return new RoleRecord { Name = name, Description = description };
    }

    private static RegisterRoleDomainResponse MapToResponse(
      RoleEntity role,
      RegisterRoleDomainRequest request
    )
    {
      return new RegisterRoleDomainResponse
      {
        RoleId = role.RoleId.Value,
        Name = role.Name.Value,
        Description = role.Description?.Value,
        Disabled = role.Disabled.Value,
        Skills = request.Skills,
      };
    }
  }
}
