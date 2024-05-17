using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Entities;
using QueryBank.Domain.Entities.Structs;
using QueryBank.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace QueryBank.Domain.Aggregates.Helpers
{
  internal class RegisterSkillHelper
    : BaseHelper,
      IHelper<RegisterSkillDomainRequest, RegisterSkillDomainResponse>
  {
    public static RegisterSkillDomainResponse Execute(RegisterSkillDomainRequest data)
    {
      var @struct = GetSkillRole(data);
      ValidateStructureFields(@struct);

      var skill = new SkillEntity();
      skill.Register(@struct.Name, @struct.SkillId, @struct.SubSkillId, @struct.Disabled);

      return MapToResponse(skill);
    }

    private static SkillStruct GetSkillRole(RegisterSkillDomainRequest data)
    {
      var id = new SkillIdValueObject(data.SkillId);
      var name = new NameValueObject(data.Name);
      var disabled = new DisabledValueObject(data.Disable);
      if (data.SubSkillId != null)
      {
        var subSkillId = new SkillIdValueObject(data.SubSkillId);
        return new SkillStruct
        {
          SkillId = id,
          SubSkillId = subSkillId,
          Name = name,
          Disabled = disabled,
        };
      }
      return new SkillStruct
      {
        SkillId = id,
        Name = name,
        Disabled = disabled,
      };
    }

    private static RegisterSkillDomainResponse MapToResponse(SkillEntity skill)
    {
      return new RegisterSkillDomainResponse
      {
        SkillId = skill.SkillId.Value,
        SubSkillId = skill.SubSkillId?.Value,
        Name = skill.Name.Value,
        Disabled = skill.Disabled.Value
      };
    }
  }
}
