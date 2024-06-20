using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Common.Enums;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.ValueObjects;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class UpdateCountryHelper
    : BaseHelper,
      IHelper<UpdateCountryDomainRequest, UpdateCountryDomainResponse>
  {
    public static Result<UpdateCountryDomainResponse> Execute(UpdateCountryDomainRequest data)
    {
      var record = GetCountryRecord(data);
      var country = new CountryEntity(record);
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

      ValidateRecordFields(country);
      ValidateAmountDataToBeUpdated(response);

      return Response<UpdateCountryDomainResponse>.Success(response);
    }

    private static CountryRecord GetCountryRecord(UpdateCountryDomainRequest data)
    {
      var id = new CountryIdValueObject(data.CountryId);
      return new CountryRecord { CountryId = id };
    }

    private static Result<bool> ValidateAmountDataToBeUpdated(UpdateCountryDomainResponse response)
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
