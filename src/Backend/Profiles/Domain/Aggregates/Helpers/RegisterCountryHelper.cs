using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class RegisterCountryHelper
    : BaseHelper,
      IHelper<RegisterCountryDomainRequest, RegisterCountryDomainResponse>
  {
    public static Result<RegisterCountryDomainResponse> Execute(RegisterCountryDomainRequest data)
    {
      var record = GetCountryRecord(data);
      var response = ValidateRecordFields(record);

      if (response.IsFailure)
      {
        return Response<RegisterCountryDomainResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var country = new CountryEntity();
      country.Register(record.Name);

      return Response<RegisterCountryDomainResponse>.Success(MapToResponse(country));
    }

    private static CountryRecord GetCountryRecord(RegisterCountryDomainRequest request)
    {
      var name = new NameValueObject(request.Name);

      return new CountryRecord { Name = name };
    }

    private static RegisterCountryDomainResponse MapToResponse(CountryEntity country)
    {
      return new RegisterCountryDomainResponse
      {
        CountryId = country.CountryId.Value,
        Name = country.Name.Value,
        Disabled = country.Disabled.Value
      };
    }
  }
}
