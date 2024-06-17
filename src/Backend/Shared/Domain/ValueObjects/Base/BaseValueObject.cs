namespace Shared.Domain.ValueObjects.Base
{
  public abstract class BaseValueObject<TData>(TData value) : BaseValueObjectErrorHandler
  {
    public TData Value { get; } = value;
    protected string Name { get; set; } = "Field name not set";
  }
}
