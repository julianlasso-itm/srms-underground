using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects;

public abstract class NameValueObject : BaseStringValueObject
{
    private const int MaxLength = 80;

    protected NameValueObject(string value)
        : base(value)
    {
        Name = "Name";
        Validate();
    }

    public sealed override void Validate()
    {
        base.Validate();
        if (!IsLengthValid(Value))
        {
            AddError(
                new ErrorValueObject(Name, $"{Name} must be less than {MaxLength} characters")
            );
        }
    }

    private static bool IsLengthValid(string value)
    {
        return value.Length <= MaxLength;
    }
}
