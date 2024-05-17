using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Structs;
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
      var @struct = GetCountryStruct(data);
      ValidateStructureFields(@struct);
      return MapToResponse(@struct);
    }

    private static CountryStruct GetCountryStruct(DeleteCountryDomainRequest data)
    {
      var id = new CountryIdValueObject(data.CountryId);
      return new CountryStruct { CountryId = id };
    }

    private static DeleteCountryDomainResponse MapToResponse(CountryStruct country)
    {
      return new DeleteCountryDomainResponse { CountryId = country.CountryId.Value };
    }
  }
}
