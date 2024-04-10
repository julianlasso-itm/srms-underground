namespace Shared.Domain.ValueObjects.Base;

public abstract class BaseValueObject<TData> : BaseValueObjectErrorHandler
{
    public TData Value { get; }
    protected string Name { get; set; }

    public BaseValueObject(TData value)
    {
        Value = value;
        Name = "Field name not set";
    }
}
