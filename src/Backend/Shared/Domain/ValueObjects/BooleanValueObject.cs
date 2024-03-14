using Shared.Domain.ValueObjects.Base;

namespace Shared.Domain.ValueObjects;

public abstract class BooleanValueObject : BaseValueObject<bool>
{
    protected BooleanValueObject(bool value) : base(value) { }

    public override void Validate()
    {
        Errors = new List<ErrorValueObject>();
        if (Value == default)
        {
            AddError(new ErrorValueObject(Name, $"{Name} is required"));
        }
    }
}
