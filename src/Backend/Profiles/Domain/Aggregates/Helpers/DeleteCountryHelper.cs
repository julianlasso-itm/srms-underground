using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class DeleteCountryHelper
    : BaseHelper,
      IHelper<DeleteCountryDomainRequest, DeleteCountryDomainResponse>
  {
    public static DeleteCountryDomainResponse Execute(DeleteCountryDomainRequest data)
    {
      var record = GetCountryRecord(data);
      ValidateRecordFields(record);
      return MapToResponse(record);
    }

    private static CountryRecord GetCountryRecord(DeleteCountryDomainRequest data)
    {
      var id = new CountryIdValueObject(data.CountryId);
      return new CountryRecord { CountryId = id };
    }

    private static DeleteCountryDomainResponse MapToResponse(CountryRecord country)
    {
      return new DeleteCountryDomainResponse { CountryId = country.CountryId.Value };
    }
  }
}
