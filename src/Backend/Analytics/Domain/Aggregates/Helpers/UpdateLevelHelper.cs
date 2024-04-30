using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;
using Analytics.Domain.Entities;
using Analytics.Domain.Entities.Structs;
using Analytics.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;

namespace Analytics.Domain.Aggregates.Helpers
{
  internal abstract class UpdateLevelHelper
    : BaseHelper,
      IHelper<UpdateLevelDomainRequest, UpdateLevelDomainResponse>
  {
    public static UpdateLevelDomainResponse Execute(UpdateLevelDomainRequest data)
    {
      var @struct = GetLevelStruct(data);
      var Level = new LevelEntity(@struct);
      var response = new UpdateLevelDomainResponse { LevelId = Level.LevelId.Value };

      if (data.Name != null)
      {
        var name = new NameValueObject(data.Name);
        Level.UpdateName(name);
        response.Name = Level.Name.Value;
      }

      if (data.Description != null)
      {
        var description = new DescriptionValueObject(data.Description);
        Level.UpdateDescription(description);
        response.Description = Level.Description?.Value;
      }

      if (data.Disable != null)
      {
        if (data.Disable == true)
        {
          Level.Disable();
        }
        else
        {
          Level.Enable();
        }
        response.Disabled = Level.Disabled.Value;
      }

      ValidateStructureFields(Level);
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
