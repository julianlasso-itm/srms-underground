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

internal abstract class UpdateProvinceHelper
    : BaseHelper,
        IHelper<UpdateProvinceDomainRequest, UpdateProvinceDomainResponse>
{
    public static UpdateProvinceDomainResponse Execute(UpdateProvinceDomainRequest data)
    {
        var @struct = GetProvinceStruct(data);
        var province = new ProvinceEntity(@struct);
        var response = new UpdateProvinceDomainResponse { ProvinceId = province.ProvinceId.Value };

        if (data.CountryId != null)
        {
            var countryId = new CountryIdValueObject(data.CountryId);
            province.UpdateCountry(countryId);
            response.CountryId = province.CountryId.Value;
        }

        if (data.Name != null)
        {
            var name = new NameValueObject(data.Name);
            province.UpdateName(name);
            response.Name = province.Name.Value;
        }

        if (data.Disable != null)
        {
            if (data.Disable == true)
            {
                province.Disable();
            }
            else
            {
                province.Enable();
            }
            response.Disabled = province.Disabled.Value;
        }

        ValidateStructureFields(province);
        ValidateAmountDataToBeUpdated(response);

        return response;
    }

    private static ProvinceStruct GetProvinceStruct(UpdateProvinceDomainRequest data)
    {
        var id = new ProvinceIdValueObject(data.ProvinceId);
        return new ProvinceStruct { ProvinceId = id };
    }

    private static void ValidateAmountDataToBeUpdated(UpdateProvinceDomainResponse response)
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
