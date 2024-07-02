using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Entities;
using QueryBank.Domain.Entities.Records;
using QueryBank.Domain.ValueObjects;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace QueryBank.Domain.Aggregates.Helpers
{
  internal class RegisterSkillHelper
    : BaseHelper,
      IHelper<RegisterSkillDomainRequest, RegisterSkillDomainResponse>
  {
    public static Result<RegisterSkillDomainResponse> Execute(RegisterSkillDomainRequest data)
    {
      var record = GetSkillRole(data);
      var result = ValidateRecordFields(record);

      if (result.IsFailure)
      {
        return Response<RegisterSkillDomainResponse>.Failure(
          result.Message,
          result.Code,
          result.Details
        );
      }

      var skill = new SkillEntity();
      skill.Register(record.Name, record.SkillId, record.SubSkillId, record.Disabled);

      return Response<RegisterSkillDomainResponse>.Success(MapToResponse(skill));
    }

    private static SkillRecord GetSkillRole(RegisterSkillDomainRequest data)
    {
      var id = new SkillIdValueObject(data.SkillId);
      var name = new NameValueObject(data.Name);
      var disabled = new DisabledValueObject(data.Disable);
      if (data.SubSkillId != null)
      {
        var subSkillId = new SkillIdValueObject(data.SubSkillId);
        return new SkillRecord
        {
          SkillId = id,
          SubSkillId = subSkillId,
          Name = name,
          Disabled = disabled,
        };
      }
      return new SkillRecord
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
