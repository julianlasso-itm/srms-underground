using Analytics.Domain.Aggregates.Dto;
using Analytics.Domain.Entities;
using Analytics.Domain.Entities.Structs;
using Analytics.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Analytics.Domain.Aggregates.Helpers;

internal abstract class UpdateLevelHelper : BaseHelper, IHelper<UpdateLevel, UpdateLevelResponse>
{
    public static UpdateLevelResponse Execute(UpdateLevel data)
    {
        var updateLevel = GetLevelStruct(data);
        ValidateStructureFields(updateLevel);

        var level = new LevelEntity(new LevelStruct { LevelId = updateLevel.LevelId });
        level.UpdateName(updateLevel.Name);
        if (updateLevel.Description != null)
        {
            level.UpdateDescription(updateLevel.Description);
        }
        if (updateLevel.Disabled != null)
        {
            if (updateLevel.Disabled.Value)
            {
                level.Disable();
            }
            else
            {
                level.Enable();
            }
        }

        return new UpdateLevelResponse
        {
            LevelId = level.LevelId.Value,
            Name = level.Name.Value,
            Description = level.Description?.Value,
            Disabled = level.Disabled.Value,
        };
    }

    private static LevelStruct GetLevelStruct(UpdateLevel data)
    {
        var response = new LevelStruct();
        response.LevelId = new LevelIdValueObject(data.LevelId);

        if (data.Name != null)
        {
            response.Name = new NameValueObject(data.Name);
            ;
        }

        if (data.Description != null)
        {
            response.Description = new DescriptionValueObject(data.Description);
        }

        if (data.Disabled != null)
        {
            response.Disabled = new DisabledValueObject((bool)data.Disabled);
        }

        return response;
    }
}
