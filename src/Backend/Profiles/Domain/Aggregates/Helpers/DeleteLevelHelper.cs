using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
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

    private static LevelRecord GetLevelRecord(DeleteLevelDomainRequest request)
    {
      var id = new LevelIdValueObject(request.LevelId);
      return new LevelRecord { LevelId = id };
    }

    private static DeleteLevelDomainResponse MapToResponse(LevelRecord Level)
    {
      return new DeleteLevelDomainResponse { LevelId = Level.LevelId.Value };
    }
  }
}
