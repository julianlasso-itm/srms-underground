using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal abstract class RegisterCityHelper
    : BaseHelper,
      IHelper<RegisterCityDomainRequest, RegisterCityDomainResponse>
  {
    public static RegisterCityDomainResponse Execute(RegisterCityDomainRequest data)
    {
      var @struct = GetCityStruct(data);
      ValidateStructureFields(@struct);

      var city = new CityEntity();
      city.Register(@struct.ProvinceId, @struct.Name);

      return MapToResponse(city);
    }

    private static CityStruct GetCityStruct(RegisterCityDomainRequest request)
    {
      var name = new NameValueObject(request.Name);
      var provinceId = new ProvinceIdValueObject(request.ProvinceId);

      return new CityStruct { Name = name, ProvinceId = provinceId };
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
