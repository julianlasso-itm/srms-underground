﻿using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;

namespace Profiles.Domain.Aggregates.Helpers
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

      if (data.Disable != null)
      {
        if (data.Disable == true)
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
