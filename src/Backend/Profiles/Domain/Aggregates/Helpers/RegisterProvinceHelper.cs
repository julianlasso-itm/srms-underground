using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal abstract class RegisterProvinceHelper
    : BaseHelper,
      IHelper<RegisterProvinceDomainRequest, RegisterProvinceDomainResponse>
  {
    public static RegisterProvinceDomainResponse Execute(RegisterProvinceDomainRequest data)
    {
      var @struct = GetProvinceStruct(data);
      ValidateStructureFields(@struct);

      var province = new ProvinceEntity();
      province.Register(@struct.CountryId, @struct.Name);

      return MapToResponse(province);
    }

    private static ProvinceStruct GetProvinceStruct(RegisterProvinceDomainRequest request)
    {
      var name = new NameValueObject(request.Name);
      var countryId = new CountryIdValueObject(request.CountryId);

      return new ProvinceStruct { Name = name, CountryId = countryId };
    }

    private static RegisterProvinceDomainResponse MapToResponse(ProvinceEntity country)
    {
      return new RegisterProvinceDomainResponse
      {
        CountryId = country.CountryId.Value,
        ProvinceId = country.ProvinceId.Value,
        Name = country.Name.Value,
        Disabled = country.Disabled.Value
      };
    }
  }
}
