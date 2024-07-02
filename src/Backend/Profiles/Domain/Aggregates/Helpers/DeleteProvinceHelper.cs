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
  internal class DeleteProvinceHelper
    : BaseHelper,
      IHelper<DeleteProvinceDomainRequest, DeleteProvinceDomainResponse>
  {
    public static Result<DeleteProvinceDomainResponse> Execute(DeleteProvinceDomainRequest data)
    {
      var record = GetProvinceRecord(data);
      var response = ValidateRecordFields(record);

      if (response.IsFailure)
      {
        return Response<DeleteProvinceDomainResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<DeleteProvinceDomainResponse>.Success(MapToResponse(record));
    }

    private static ProvinceRecord GetProvinceRecord(DeleteProvinceDomainRequest data)
    {
      var id = new ProvinceIdValueObject(data.ProvinceId);
      return new ProvinceRecord { ProvinceId = id };
    }

    private static DeleteProvinceDomainResponse MapToResponse(ProvinceRecord country)
    {
      return new DeleteProvinceDomainResponse { ProvinceId = country.ProvinceId.Value };
    }
  }
}
