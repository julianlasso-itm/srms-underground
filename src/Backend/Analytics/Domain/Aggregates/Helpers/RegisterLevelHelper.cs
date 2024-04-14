using Analytics.Domain.Aggregates.Dto;
using Analytics.Domain.Entities;
using Analytics.Domain.Entities.Structs;
using Analytics.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Analytics.Domain.Aggregates.Helpers;

internal abstract class RegisterLevelHelper
    : BaseHelper,
        IHelper<RegisterLevel, RegisterLevelResponse>
{
    public static RegisterLevelResponse Execute(RegisterLevel data)
    {
        var newLevel = GetLevelStruct(data);
        ValidateStructureFields(newLevel);

        var level = new LevelEntity();
        level.Register(newLevel.Name, newLevel.Description);

        return new RegisterLevelResponse
        {
            LevelId = level.LevelId.Value,
            Name = level.Name.Value,
            Description = level.Description?.Value,
            Disabled = level.Disabled.Value,
        };
    }

    public static void Execute()
    {
        throw new NotImplementedException();
    }

    private static LevelStruct GetLevelStruct(RegisterLevel data)
    {
        var name = new NameValueObject(data.Name);
        var description =
            data.Description != null ? new DescriptionValueObject(data.Description) : null;

        return new LevelStruct { Name = name, Description = description };
    }
}
