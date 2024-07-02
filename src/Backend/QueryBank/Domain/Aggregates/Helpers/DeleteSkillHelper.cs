using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Entities.Records;
using QueryBank.Domain.ValueObjects;
using Shared.Common;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace QueryBank.Domain.Aggregates.Helpers
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
