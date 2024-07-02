using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Enums;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.ValueObjects;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class UpdateCityHelper
    : BaseHelper,
      IHelper<UpdateCityDomainRequest, UpdateCityDomainResponse>
  {
    public static Result<UpdateCityDomainResponse> Execute(UpdateCityDomainRequest data)
    {
      var record = GetCityRecord(data);
      var city = new CityEntity(record);
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

      var validateRecordFields = ValidateRecordFields(city);

      if (validateRecordFields.IsFailure)
      {
        return Response<UpdateCityDomainResponse>.Failure(
          validateRecordFields.Message,
          validateRecordFields.Code,
          validateRecordFields.Details
        );
      }

      var validateAmountDataToBeUpdated = ValidateAmountDataToBeUpdated(response);

      if (validateAmountDataToBeUpdated.IsFailure)
      {
        return Response<UpdateCityDomainResponse>.Failure(
          validateAmountDataToBeUpdated.Message,
          validateAmountDataToBeUpdated.Code,
          validateAmountDataToBeUpdated.Details
        );
      }

      return Response<UpdateCityDomainResponse>.Success(response);
    }

    private static CityRecord GetCityRecord(UpdateCityDomainRequest data)
    {
      var id = new CityIdValueObject(data.CityId);
      return new CityRecord { CityId = id };
    }

    private static Result<bool> ValidateAmountDataToBeUpdated(UpdateCityDomainResponse response)
    {
      var count = response.GetType().GetProperties().Count(x => x.GetValue(response) != null);
      if (count == 1)
      {
        return Response<bool>.Failure(
          "No data to update",
          ErrorEnum.BAD_REQUEST,
          new ErrorValueObject("Fields", "No fields to update")
        );
      }

      return Response<bool>.Success();
    }
  }
}
