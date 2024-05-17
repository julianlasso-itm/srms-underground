using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class RegisterLevelHelper
    : BaseHelper,
      IHelper<RegisterLevelDomainRequest, RegisterLevelDomainResponse>
  {
    public static RegisterLevelDomainResponse Execute(RegisterLevelDomainRequest request)
    {
      var record = GetLevelRecord(request);
      ValidateRecordFields(record);

      var level = new LevelEntity();
      level.Register(record.Name, record.Description, record.LevelId, record.Disabled);

      return MapToResponse(level);
    }

    private static LevelRecord GetLevelRecord(RegisterLevelDomainRequest request)
    {
      var name = new NameValueObject(request.Name);
      var description =
        request.Description != null ? new DescriptionValueObject(request.Description) : null;

      if (request.LevelId != null && request.Disabled != null)
      {
        var id = new LevelIdValueObject(request.LevelId);
        var disabled = new DisabledValueObject(request.Disabled.Value);
        return new LevelRecord
        {
          LevelId = id,
          Name = name,
          Description = description,
          Disabled = disabled
        };
      }
      return new LevelRecord { Name = name, Description = description };
    }

    private static RegisterLevelDomainResponse MapToResponse(LevelEntity level)
    {
      return new RegisterLevelDomainResponse
      {
        LevelId = level.LevelId.Value,
        Name = level.Name.Value,
        Description = level.Description?.Value,
        Disabled = level.Disabled.Value,
      };
    }
  }
}
