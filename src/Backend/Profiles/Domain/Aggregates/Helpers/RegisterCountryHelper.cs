using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class RegisterCountryHelper
    : BaseHelper,
      IHelper<RegisterCountryDomainRequest, RegisterCountryDomainResponse>
  {
    public static RegisterCountryDomainResponse Execute(RegisterCountryDomainRequest data)
    {
      var @struct = GetCountryStruct(data);
      ValidateStructureFields(@struct);

      var country = new CountryEntity();
      country.Register(@struct.Name);

      return MapToResponse(country);
    }

    private static CountryStruct GetCountryStruct(RegisterCountryDomainRequest request)
    {
      var name = new NameValueObject(request.Name);

      return new CountryStruct { Name = name };
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
