namespace Shared.Domain.ValueObjects.Base
{
  public abstract class BaseStringValueObject(string value) : BaseValueObject<string>(value)
  {
    public override void Validate()
    {
      Errors = new List<ErrorValueObject>();
      if (string.IsNullOrWhiteSpace(Value))
      {
        AddError(new ErrorValueObject(Name, $"{Name} is required"));
        return;
      }
    }
  }
}
