using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class DeleteCityHelper
    : BaseHelper,
      IHelper<DeleteCityDomainRequest, DeleteCityDomainResponse>
  {
    public static DeleteCityDomainResponse Execute(DeleteCityDomainRequest data)
    {
      var record = GetCityRecord(data);
      ValidateRecordFields(record);
      return MapToResponse(record);
    }

    private static CityRecord GetCityRecord(DeleteCityDomainRequest data)
    {
      var id = new CityIdValueObject(data.CityId);
      return new CityRecord { CityId = id };
    }

    private static DeleteCityDomainResponse MapToResponse(CityRecord country)
    {
      return new DeleteCityDomainResponse { CityId = country.CityId.Value };
    }
  }
}
