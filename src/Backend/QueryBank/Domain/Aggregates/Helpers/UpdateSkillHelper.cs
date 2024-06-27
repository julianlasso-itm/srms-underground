using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Entities;
using QueryBank.Domain.Entities.Records;
using QueryBank.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Common.Enums;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.ValueObjects;

namespace QueryBank.Domain.Aggregates.Helpers
{
  internal class UpdateSkillHelper
    : BaseHelper,
      IHelper<UpdateSkillDomainRequest, UpdateSkillDomainResponse>
  {
    public static Result<UpdateSkillDomainResponse> Execute(UpdateSkillDomainRequest data)
    {
      var record = GetSkillRecord(data);
      var skill = new SkillEntity(record);
      var response = new UpdateSkillDomainResponse { SkillId = skill.SkillId.Value };

      if (data.Name != null)
      {
        var name = new NameValueObject(data.Name);
        skill.UpdateName(name);
        response.Name = skill.Name.Value;
      }

      if (data.Disabled != null)
      {
        if (data.Disabled == true)
        {
          skill.Disable();
        }
        else
        {
          skill.Enable();
        }
        response.Disabled = skill.Disabled.Value;
      }

      var validateRecordFields = ValidateRecordFields(skill);
      if (validateRecordFields.IsFailure)
      {
        return Response<UpdateSkillDomainResponse>.Failure(
          validateRecordFields.Message,
          validateRecordFields.Code,
          validateRecordFields.Details
        );
      }

      var validateAmountDataToBeUpdated = ValidateAmountDataToBeUpdated(response);
      if (validateAmountDataToBeUpdated.IsFailure)
      {
        return Response<UpdateSkillDomainResponse>.Failure(
          validateAmountDataToBeUpdated.Message,
          validateAmountDataToBeUpdated.Code,
          validateAmountDataToBeUpdated.Details
        );
      }

      return Response<UpdateSkillDomainResponse>.Success(response);
    }

    private static Result<bool> ValidateAmountDataToBeUpdated(UpdateSkillDomainResponse response)
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

    private static SkillRecord GetSkillRecord(UpdateSkillDomainRequest data)
    {
      var id = new SkillIdValueObject(data.SkillId);
      return new SkillRecord { SkillId = id };
    }
  }
}
