using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class DeleteSkillHelper
    : BaseHelper,
      IHelper<DeleteSkillDomainRequest, DeleteSkillDomainResponse>
  {
    public static Result<DeleteSkillDomainResponse> Execute(DeleteSkillDomainRequest request)
    {
      var record = GetSkillRecord(request);
      var response = ValidateRecordFields(record);

      if (response.IsFailure)
      {
        return Response<DeleteSkillDomainResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<DeleteSkillDomainResponse>.Success(
        new DeleteSkillDomainResponse { SkillId = record.SkillId.Value }
      );
    }

    private static SkillRecord GetSkillRecord(DeleteSkillDomainRequest request)
    {
      var id = new SkillIdValueObject(request.SkillId);
      return new SkillRecord { SkillId = id };
    }
  }
}
