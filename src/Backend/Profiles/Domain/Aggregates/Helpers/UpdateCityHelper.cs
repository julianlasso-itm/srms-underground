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

internal abstract class UpdateCityHelper
    : BaseHelper,
        IHelper<UpdateCityDomainRequest, UpdateCityDomainResponse>
{
    public static UpdateCityDomainResponse Execute(UpdateCityDomainRequest data)
    {
        var @struct = GetCityStruct(data);
        var city = new CityEntity(@struct);
        var response = new UpdateCityDomainResponse { CityId = city.CityId.Value };

        if (data.ProvinceId != null)
        {
            var provinceId = new ProvinceIdValueObject(data.ProvinceId);
            city.UpdateProvince(provinceId);
            response.ProvinceId = city.ProvinceId.Value;
        }

        if (data.Name != null)
        {
            var name = new NameValueObject(data.Name);
            city.UpdateName(name);
            response.Name = city.Name.Value;
        }

        if (data.Disable != null)
        {
            if (data.Disable == true)
            {
                city.Disable();
            }
            else
            {
                city.Enable();
            }
            response.Disabled = city.Disabled.Value;
        }

        ValidateStructureFields(city);
        ValidateAmountDataToBeUpdated(response);

        return response;
    }

    private static CityStruct GetCityStruct(UpdateCityDomainRequest data)
    {
        var id = new CityIdValueObject(data.CityId);
        return new CityStruct { CityId = id };
    }

    private static void ValidateAmountDataToBeUpdated(UpdateCityDomainResponse response)
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
