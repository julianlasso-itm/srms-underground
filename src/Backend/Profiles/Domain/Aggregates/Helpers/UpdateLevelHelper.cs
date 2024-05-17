using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class UpdateLevelHelper
    : BaseHelper,
      IHelper<UpdateLevelDomainRequest, UpdateLevelDomainResponse>
  {
    public static UpdateLevelDomainResponse Execute(UpdateLevelDomainRequest data)
    {
      var @struct = GetLevelStruct(data);
      var level = new LevelEntity(@struct);
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

      ValidateStructureFields(level);
      ValidateAmountDataToBeUpdated(response);

      return response;
    }

    private static LevelStruct GetLevelStruct(UpdateLevelDomainRequest data)
    {
      var id = new LevelIdValueObject(data.LevelId);
      return new LevelStruct { LevelId = id };
    }

    private static void ValidateAmountDataToBeUpdated(UpdateLevelDomainResponse response)
    {
      var count = response.GetType().GetProperties().Count(x => x.GetValue(response) != null);
      if (count == 1)
      {
        throw new DomainException(
          "No data to update",
          [new ErrorValueObject("No fields to update", "No fields to update")]
        );
      }
    }
  }
}
