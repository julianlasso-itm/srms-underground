namespace Shared.Domain.ValueObjects.Base;

public abstract class BaseIdValueObject : BaseStringValueObject
{
    protected BaseIdValueObject(string value)
        : base(value) { }

    public override void Validate()
    {
        base.Validate();
        if (!IsUUIDValid(Value))
        {
            AddError(new ErrorValueObject(Name, $"{Name} is not a valid UUID"));
        }
    }

    private static bool IsUUIDValid(string value)
    {
        return Guid.TryParse(value, out _);
    }
}
