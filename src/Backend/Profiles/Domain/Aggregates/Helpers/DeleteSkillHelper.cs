using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class DeleteSkillHelper
    : BaseHelper,
      IHelper<DeleteSkillDomainRequest, DeleteSkillDomainResponse>
  {
    public static DeleteSkillDomainResponse Execute(DeleteSkillDomainRequest request)
    {
      var record = GetSkillRecord(request);
      ValidateRecordFields(record);
      return new DeleteSkillDomainResponse { SkillId = record.SkillId.Value };
    }

    private static SkillRecord GetSkillRecord(DeleteSkillDomainRequest request)
    {
      var id = new SkillIdValueObject(request.SkillId);
      return new SkillRecord { SkillId = id };
    }
  }
}
