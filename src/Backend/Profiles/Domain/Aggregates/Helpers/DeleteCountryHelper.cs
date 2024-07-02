using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Common;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class DeleteCountryHelper
    : BaseHelper,
      IHelper<DeleteCountryDomainRequest, DeleteCountryDomainResponse>
  {
    public static Result<DeleteCountryDomainResponse> Execute(DeleteCountryDomainRequest data)
    {
      var record = GetCountryRecord(data);
      var response = ValidateRecordFields(record);

      if (response.IsFailure)
      {
        return Response<DeleteCountryDomainResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<DeleteCountryDomainResponse>.Success(MapToResponse(record));
    }

    private static CountryRecord GetCountryRecord(DeleteCountryDomainRequest data)
    {
      var id = new CountryIdValueObject(data.CountryId);
      return new CountryRecord { CountryId = id };
    }

    private static DeleteCountryDomainResponse MapToResponse(CountryRecord country)
    {
      return new DeleteCountryDomainResponse { CountryId = country.CountryId.Value };
    }
  }
}
