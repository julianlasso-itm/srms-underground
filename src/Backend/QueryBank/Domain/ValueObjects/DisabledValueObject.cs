using Shared.Domain.ValueObjects.Base;

namespace QueryBank.Domain.ValueObjects;

public sealed class DisabledValueObject : BaseBooleanValueObject
{
    public DisabledValueObject(bool value)
        : base(value)
    {
        Name = "Disabled";
        Validate();
    }
}
