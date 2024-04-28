using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;

namespace Profiles.Domain.Aggregates.Helpers;

internal abstract class UpdateCountryHelper
    : BaseHelper,
        IHelper<UpdateCountryDomainRequest, UpdateCountryDomainResponse>
{
    public static UpdateCountryDomainResponse Execute(UpdateCountryDomainRequest data)
    {
        var @struct = GetCountryStruct(data);
        var country = new CountryEntity(@struct);
        var response = new UpdateCountryDomainResponse { CountryId = country.CountryId.Value };

        if (data.Name != null)
        {
            var name = new NameValueObject(data.Name);
            country.UpdateName(name);
            response.Name = country.Name.Value;
        }

        if (data.Disable != null)
        {
            if (data.Disable == true)
            {
                country.Disable();
            }
            else
            {
                country.Enable();
            }
            response.Disabled = country.Disabled.Value;
        }

        ValidateStructureFields(country);
        ValidateAmountDataToBeUpdated(response);

        return response;
    }

    private static CountryStruct GetCountryStruct(UpdateCountryDomainRequest data)
    {
        var id = new CountryIdValueObject(data.CountryId);
        return new CountryStruct { CountryId = id };
    }

    private static void ValidateAmountDataToBeUpdated(UpdateCountryDomainResponse response)
    {
        var count = response.GetType().GetProperties().Count(x => x.GetValue(response) != null);
        if (count == 1)
        {
            throw new DomainException(
                "No data to update",
                [new ErrorValueObject("No field to update", "No fields to update")]
            );
        }
    }
}
