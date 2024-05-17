using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;
using Analytics.Domain.Entities.Records;
using Analytics.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Analytics.Domain.Aggregates.Helpers
{
  internal class DeleteLevelHelper
    : BaseHelper,
      IHelper<DeleteLevelDomainRequest, DeleteLevelDomainResponse>
  {
    public static DeleteLevelDomainResponse Execute(DeleteLevelDomainRequest request)
    {
      var record = GetLevelRecord(request);
      ValidateRecordFields(record);
      return MapToResponse(record);
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
