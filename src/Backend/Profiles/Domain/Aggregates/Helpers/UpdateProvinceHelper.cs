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
  internal class UpdateProvinceHelper
    : BaseHelper,
      IHelper<UpdateProvinceDomainRequest, UpdateProvinceDomainResponse>
  {
    public static Result<UpdateProvinceDomainResponse> Execute(UpdateProvinceDomainRequest data)
    {
      var record = GetProvinceRecord(data);
      var province = new ProvinceEntity(record);
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

      var validateRecordFields = ValidateRecordFields(province);

      if (validateRecordFields.IsFailure)
      {
        return Response<UpdateProvinceDomainResponse>.Failure(
          validateRecordFields.Message,
          validateRecordFields.Code,
          validateRecordFields.Details
        );
      }

      var validateAmountDataToBeUpdated = ValidateAmountDataToBeUpdated(response);

      if (validateAmountDataToBeUpdated.IsFailure)
      {
        return Response<UpdateProvinceDomainResponse>.Failure(
          validateAmountDataToBeUpdated.Message,
          validateAmountDataToBeUpdated.Code,
          validateAmountDataToBeUpdated.Details
        );
      }

      return Response<UpdateProvinceDomainResponse>.Success(response);
    }

    private static ProvinceRecord GetProvinceRecord(UpdateProvinceDomainRequest data)
    {
      var id = new ProvinceIdValueObject(data.ProvinceId);
      return new ProvinceRecord { ProvinceId = id };
    }

    private static Result<bool> ValidateAmountDataToBeUpdated(UpdateProvinceDomainResponse response)
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
