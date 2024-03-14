namespace Shared.Domain.ValueObjects.Base;

public abstract class BaseValueObject<TypeData> : BaseValueObjectErrorHandler
{
    public TypeData Value { get; }
    protected string Name { get; set; }

    protected BaseValueObject(TypeData value)
    {
        Value = value;
        Name = "Field name not set";
        Validate();
    }
}
