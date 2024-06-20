using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;
using Analytics.Domain.Entities;
using Analytics.Domain.Entities.Records;
using Analytics.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace Analytics.Domain.Aggregates.Helpers
{
  internal class RegisterLevelHelper
    : BaseHelper,
      IHelper<RegisterLevelDomainRequest, RegisterLevelDomainResponse>
  {
    public static Result<RegisterLevelDomainResponse> Execute(RegisterLevelDomainRequest request)
    {
      var record = GetLevelRecord(request);
      var response = ValidateRecordFields(record);

      if (response.IsFailure)
      {
        return Response<RegisterLevelDomainResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var level = new LevelEntity();
      level.Register(record.Name, record.Description);

      return Response<RegisterLevelDomainResponse>.Success(MapToResponse(level));
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
