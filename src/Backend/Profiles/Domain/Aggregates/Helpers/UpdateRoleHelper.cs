using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Enums;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.ValueObjects;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class UpdateRoleHelper
    : BaseHelper,
      IHelper<UpdateRoleDomainRequest, UpdateRoleDomainResponse>
  {
    public static Result<UpdateRoleDomainResponse> Execute(UpdateRoleDomainRequest data)
    {
      var record = GetRoleRecord(data);
      var role = new RoleEntity(record);
      var response = new UpdateRoleDomainResponse { RoleId = role.RoleId.Value };

      if (data.Name != null)
      {
        var name = new NameValueObject(data.Name);
        role.UpdateName(name);
        response.Name = role.Name.Value;
      }

      if (data.Description != null)
      {
        var description = new DescriptionValueObject(data.Description);
        role.UpdateDescription(description);
        response.Description = role.Description?.Value;
      }

      if (data.Disable != null)
      {
        if (data.Disable == true)
        {
          role.Disable();
        }
        else
        {
          role.Enable();
        }
        response.Disabled = role.Disabled.Value;
      }

      var validateRecordFields = ValidateRecordFields(role);

      if (validateRecordFields.IsFailure)
      {
        return Response<UpdateRoleDomainResponse>.Failure(
          validateRecordFields.Message,
          validateRecordFields.Code,
          validateRecordFields.Details
        );
      }

      var validateAmountDataToBeUpdated = ValidateAmountDataToBeUpdated(response);

      if (validateAmountDataToBeUpdated.IsFailure)
      {
        return Response<UpdateRoleDomainResponse>.Failure(
          validateAmountDataToBeUpdated.Message,
          validateAmountDataToBeUpdated.Code,
          validateAmountDataToBeUpdated.Details
        );
      }

      if (data.Skills != null)
      {
        response.Skills = data.Skills;
      }

      return Response<UpdateRoleDomainResponse>.Success(response);
    }

    private static RoleRecord GetRoleRecord(UpdateRoleDomainRequest data)
    {
      var id = new RoleIdValueObject(data.RoleId);
      return new RoleRecord { RoleId = id };
    }

    private static Result<bool> ValidateAmountDataToBeUpdated(UpdateRoleDomainResponse response)
    {
      var count = response.GetType().GetProperties().Count(x => x.GetValue(response) != null);
      if (count == 1)
      {
        return Response<bool>.Failure(
          "No data to update",
          ErrorEnum.BAD_REQUEST,
          new ErrorValueObject("Fields", "No fields to update")
        );
      }

      return Response<bool>.Success();
    }
  }
}
