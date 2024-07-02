using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;
using Analytics.Domain.Entities;
using Analytics.Domain.Entities.Records;
using Analytics.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Enums;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.ValueObjects;

namespace Analytics.Domain.Aggregates.Helpers
{
  internal class UpdateLevelHelper
    : BaseHelper,
      IHelper<UpdateLevelDomainRequest, UpdateLevelDomainResponse>
  {
    public static Result<UpdateLevelDomainResponse> Execute(UpdateLevelDomainRequest data)
    {
      var record = GetLevelRecord(data);
      var level = new LevelEntity(record);
      var response = new UpdateLevelDomainResponse { LevelId = level.LevelId.Value };

      if (data.Name != null)
      {
        var name = new NameValueObject(data.Name);
        level.UpdateName(name);
        response.Name = level.Name.Value;
      }

      if (data.Description != null)
      {
        var description = new DescriptionValueObject(data.Description);
        level.UpdateDescription(description);
        response.Description = level.Description?.Value;
      }

      if (data.Disable != null)
      {
        if (data.Disable == true)
        {
          level.Disable();
        }
        else
        {
          level.Enable();
        }
        response.Disabled = level.Disabled.Value;
      }

      var validateRecordFields = ValidateRecordFields(level);

      if (validateRecordFields.IsFailure)
      {
        return Response<UpdateLevelDomainResponse>.Failure(
          validateRecordFields.Message,
          validateRecordFields.Code,
          validateRecordFields.Details
        );
      }

      var validateAmountDataToBeUpdated = ValidateAmountDataToBeUpdated(response);

      if (validateAmountDataToBeUpdated.IsFailure)
      {
        return Response<UpdateLevelDomainResponse>.Failure(
          validateAmountDataToBeUpdated.Message,
          validateAmountDataToBeUpdated.Code,
          validateAmountDataToBeUpdated.Details
        );
      }

      return Response<UpdateLevelDomainResponse>.Success(response);
    }

    private static LevelRecords GetLevelRecord(UpdateLevelDomainRequest data)
    {
      var id = new LevelIdValueObject(data.LevelId);
      return new LevelRecords { LevelId = id };
    }

    private static Result<bool> ValidateAmountDataToBeUpdated(UpdateLevelDomainResponse response)
    {
      var count = response.GetType().GetProperties().Count(x => x.GetValue(response) != null);
      if (count == 1)
      {
        return Response<bool>.Failure(
          "No data to update",
          ErrorEnum.BAD_REQUEST,
          new List<ErrorValueObject>
          {
            new ErrorValueObject("No fields to update", "No fields to update")
          }
        );
      }

      return Response<bool>.Success();
    }
  }
}
