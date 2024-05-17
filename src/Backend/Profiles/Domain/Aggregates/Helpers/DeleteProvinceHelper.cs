using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class DeleteProvinceHelper
    : BaseHelper,
      IHelper<DeleteProvinceDomainRequest, DeleteProvinceDomainResponse>
  {
    public static DeleteProvinceDomainResponse Execute(DeleteProvinceDomainRequest data)
    {
      var record = GetProvinceRecord(data);
      ValidateRecordFields(record);
      return MapToResponse(record);
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
