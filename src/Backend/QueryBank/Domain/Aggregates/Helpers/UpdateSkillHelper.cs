using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Entities;
using QueryBank.Domain.Entities.Records;
using QueryBank.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;

namespace QueryBank.Domain.Aggregates.Helpers
{
  internal class UpdateSkillHelper
    : BaseHelper,
      IHelper<UpdateSkillDomainRequest, UpdateSkillDomainResponse>
  {
    public static UpdateSkillDomainResponse Execute(UpdateSkillDomainRequest data)
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

      ValidateRecordFields(skill);
      ValidateAmountDataToBeUpdated(response);

      return response;
    }

    private static void ValidateAmountDataToBeUpdated(UpdateSkillDomainResponse response)
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

    private static SkillRecord GetSkillRecord(UpdateSkillDomainRequest data)
    {
      var id = new SkillIdValueObject(data.SkillId);
      return new SkillRecord { SkillId = id };
    }
  }
}
