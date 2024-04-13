using Shared.Domain.ValueObjects.Base;

namespace Analytics.Domain.ValueObjects;

public class DisabledValueObject : BaseBooleanValueObject
{
    public DisabledValueObject(bool value)
        : base(value)
    {
        Name = "Disable";
        Validate();
    }
}
