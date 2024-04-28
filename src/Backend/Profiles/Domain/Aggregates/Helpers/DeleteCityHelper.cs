using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers;

internal abstract class DeleteCityHelper
    : BaseHelper,
        IHelper<DeleteCityDomainRequest, DeleteCityDomainResponse>
{
    public static DeleteCityDomainResponse Execute(DeleteCityDomainRequest data)
    {
        var @struct = GetCityStruct(data);
        ValidateStructureFields(@struct);
        return MapToResponse(@struct);
    }

    private static CityStruct GetCityStruct(DeleteCityDomainRequest data)
    {
        var id = new CityIdValueObject(data.CityId);
        return new CityStruct { CityId = id };
    }

    private static DeleteCityDomainResponse MapToResponse(CityStruct country)
    {
        return new DeleteCityDomainResponse { CityId = country.CityId.Value };
    }
}
