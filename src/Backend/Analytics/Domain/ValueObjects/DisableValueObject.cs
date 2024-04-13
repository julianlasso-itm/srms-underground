using Shared.Domain.ValueObjects.Base;

namespace Analytics.Domain.ValueObjects;

public class DisableValueObject : BaseBooleanValueObject
{
    public DisableValueObject(bool value)
        : base(value)
    {
        Name = "Disable";
        Validate();
    }
}
