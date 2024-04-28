using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;
using Analytics.Domain.Entities.Structs;
using Analytics.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Analytics.Domain.Aggregates.Helpers;

internal abstract class DeleteLevelHelper
    : BaseHelper,
        IHelper<DeleteLevelDomainRequest, DeleteLevelDomainResponse>
{
    public static DeleteLevelDomainResponse Execute(DeleteLevelDomainRequest request)
    {
        var @struct = GetLevelStruct(request);
        ValidateStructureFields(@struct);
        return MapToResponse(@struct);
    }

    private static LevelStruct GetLevelStruct(DeleteLevelDomainRequest request)
    {
        var id = new LevelIdValueObject(request.LevelId);
        return new LevelStruct { LevelId = id };
    }

    private static DeleteLevelDomainResponse MapToResponse(LevelStruct Level)
    {
        return new DeleteLevelDomainResponse { LevelId = Level.LevelId.Value };
    }
}
