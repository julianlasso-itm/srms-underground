using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class RegisterSkillHelper
    : BaseHelper,
      IHelper<RegisterSkillDomainRequest, RegisterSkillDomainResponse>
  {
    public static RegisterSkillDomainResponse Execute(RegisterSkillDomainRequest data)
    {
      var record = GetSkillRole(data);
      ValidateRecordFields(record);

      var skill = new SkillEntity();
      skill.Register(record.Name);

      return new RegisterSkillDomainResponse
      {
        SkillId = skill.SkillId.Value,
        Name = skill.Name.Value,
        Disabled = skill.Disabled.Value
      };
    }

    private static SkillRecord GetSkillRole(RegisterSkillDomainRequest data)
    {
      var name = new NameValueObject(data.Name);

      return new SkillRecord { Name = name };
    }
  }
}
