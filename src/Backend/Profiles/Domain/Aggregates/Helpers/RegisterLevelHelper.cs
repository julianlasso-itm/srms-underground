using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal abstract class RegisterLevelHelper
    : BaseHelper,
      IHelper<RegisterLevelDomainRequest, RegisterLevelDomainResponse>
  {
    public static RegisterLevelDomainResponse Execute(RegisterLevelDomainRequest request)
    {
      var @struct = GetLevelStruct(request);
      ValidateStructureFields(@struct);

      var level = new LevelEntity();
      level.Register(@struct.Name, @struct.Description, @struct.LevelId, @struct.Disabled);

      return MapToResponse(level);
    }

    private static LevelStruct GetLevelStruct(RegisterLevelDomainRequest request)
    {
      var name = new NameValueObject(request.Name);
      var description =
        request.Description != null ? new DescriptionValueObject(request.Description) : null;

      if (request.LevelId != null && request.Disabled != null)
      {
        var id = new LevelIdValueObject(request.LevelId);
        var disabled = new DisabledValueObject(request.Disabled.Value);
        return new LevelStruct
        {
          LevelId = id,
          Name = name,
          Description = description,
          Disabled = disabled
        };
      }
      return new LevelStruct { Name = name, Description = description };
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
