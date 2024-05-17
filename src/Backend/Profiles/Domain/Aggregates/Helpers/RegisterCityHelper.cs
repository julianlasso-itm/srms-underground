using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class RegisterCityHelper
    : BaseHelper,
      IHelper<RegisterCityDomainRequest, RegisterCityDomainResponse>
  {
    public static RegisterCityDomainResponse Execute(RegisterCityDomainRequest data)
    {
      var record = GetCityRecord(data);
      ValidateRecordFields(record);

      var city = new CityEntity();
      city.Register(record.ProvinceId, record.Name);

      return MapToResponse(city);
    }

    private static CityRecord GetCityRecord(RegisterCityDomainRequest request)
    {
      var name = new NameValueObject(request.Name);
      var provinceId = new ProvinceIdValueObject(request.ProvinceId);

      return new CityRecord { Name = name, ProvinceId = provinceId };
    }

    private static RegisterCityDomainResponse MapToResponse(CityEntity city)
    {
      return new RegisterCityDomainResponse
      {
        CityId = city.CityId.Value,
        ProvinceId = city.ProvinceId.Value,
        Name = city.Name.Value,
        Disabled = city.Disabled.Value
      };
    }
  }
}
