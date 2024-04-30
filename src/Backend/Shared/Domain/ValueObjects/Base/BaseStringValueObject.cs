namespace Shared.Domain.ValueObjects.Base
{
  public abstract class BaseStringValueObject : BaseValueObject<string>
  {
    public BaseStringValueObject(string value)
      : base(value) { }

    public override void Validate()
    {
      Errors = new List<ErrorValueObject>();
      if (string.IsNullOrWhiteSpace(Value))
      {
        AddError(new ErrorValueObject(Name, $"{Name} is required"));
      }
    }
  }
}
