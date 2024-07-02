using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;
using Analytics.Domain.Entities.Records;
using Analytics.Domain.ValueObjects;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace Analytics.Domain.Aggregates.Helpers
{
  internal class DeleteLevelHelper
    : BaseHelper,
      IHelper<DeleteLevelDomainRequest, DeleteLevelDomainResponse>
  {
    public static Result<DeleteLevelDomainResponse> Execute(DeleteLevelDomainRequest request)
    {
      var record = GetLevelRecord(request);
      var response = ValidateRecordFields(record);

      if (response.IsFailure)
      {
        return Response<DeleteLevelDomainResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<DeleteLevelDomainResponse>.Success(MapToResponse(record));
    }

    private static LevelRecords GetLevelRecord(DeleteLevelDomainRequest request)
    {
      var id = new LevelIdValueObject(request.LevelId);
      return new LevelRecords { LevelId = id };
    }

    private static DeleteLevelDomainResponse MapToResponse(LevelRecords Level)
    {
      return new DeleteLevelDomainResponse { LevelId = Level.LevelId.Value };
    }
  }
}
