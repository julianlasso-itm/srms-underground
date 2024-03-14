using Shared.Domain.ValueObjects.Base;

namespace Shared.Domain.ValueObjects;

public abstract class StringValueObject : BaseValueObject<string>
{
    protected StringValueObject(string value) : base(value) { }

    public override void Validate()
    {
        Errors = new List<ErrorValueObject>();
        if (string.IsNullOrWhiteSpace(Value))
        {
            AddError(new ErrorValueObject(Name, $"{Name} is required"));
        }
    }
}
