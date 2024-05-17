using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
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
