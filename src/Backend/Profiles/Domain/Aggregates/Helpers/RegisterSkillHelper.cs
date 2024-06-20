using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class RegisterSkillHelper
    : BaseHelper,
      IHelper<RegisterSkillDomainRequest, RegisterSkillDomainResponse>
  {
    public static Result<RegisterSkillDomainResponse> Execute(RegisterSkillDomainRequest data)
    {
      var record = GetSkillRole(data);
      var response = ValidateRecordFields(record);

      if (response.IsFailure)
      {
        return Response<RegisterSkillDomainResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var skill = new SkillEntity();
      skill.Register(record.Name);

      return Response<RegisterSkillDomainResponse>.Success(MapToResponse(skill));
    }

    private static SkillRecord GetSkillRole(RegisterSkillDomainRequest data)
    {
      var name = new NameValueObject(data.Name);

      return new SkillRecord { Name = name };
    }

    private static RegisterSkillDomainResponse MapToResponse(SkillEntity skill)
    {
      return new RegisterSkillDomainResponse
      {
        SkillId = skill.SkillId.Value,
        Name = skill.Name.Value,
        Disabled = skill.Disabled.Value
      };
    }
  }
}
