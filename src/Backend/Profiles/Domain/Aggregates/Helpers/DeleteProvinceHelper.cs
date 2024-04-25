using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers;

internal abstract class DeleteProvinceHelper
    : BaseHelper,
        IHelper<DeleteProvinceDomainRequest, DeleteProvinceDomainResponse>
{
    public static DeleteProvinceDomainResponse Execute(DeleteProvinceDomainRequest data)
    {
        var @struct = GetProvinceStruct(data);
        ValidateStructureFields(@struct);
        return MapToResponse(@struct);
    }

    private static ProvinceStruct GetProvinceStruct(DeleteProvinceDomainRequest data)
    {
        var id = new ProvinceIdValueObject(data.ProvinceId);
        return new ProvinceStruct { ProvinceId = id };
    }

    private static DeleteProvinceDomainResponse MapToResponse(ProvinceStruct country)
    {
        return new DeleteProvinceDomainResponse { ProvinceId = country.ProvinceId.Value };
    }
}
