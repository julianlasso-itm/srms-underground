using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;
using Analytics.Domain.Entities;
using Analytics.Domain.Entities.Records;
using Analytics.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Analytics.Domain.Aggregates.Helpers
{
  internal class RegisterLevelHelper
    : BaseHelper,
      IHelper<RegisterLevelDomainRequest, RegisterLevelDomainResponse>
  {
    public static RegisterLevelDomainResponse Execute(RegisterLevelDomainRequest request)
    {
      var record = GetLevelRecord(request);
      ValidateRecordFields(record);

      var Level = new LevelEntity();
      Level.Register(record.Name, record.Description);

      return MapToResponse(Level);
    }

    private static LevelRecords GetLevelRecord(RegisterLevelDomainRequest request)
    {
      var name = new NameValueObject(request.Name);
      var description =
        request.Description != null ? new DescriptionValueObject(request.Description) : null;

      return new LevelRecords { Name = name, Description = description };
    }

    private static RegisterLevelDomainResponse MapToResponse(LevelEntity Level)
    {
      return new RegisterLevelDomainResponse
      {
        LevelId = Level.LevelId.Value,
        Name = Level.Name.Value,
        Description = Level.Description?.Value,
        Disabled = Level.Disabled.Value,
      };
    }
  }
}
