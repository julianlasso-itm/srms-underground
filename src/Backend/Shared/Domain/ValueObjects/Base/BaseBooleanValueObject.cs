namespace Shared.Domain.ValueObjects.Base
{
  public abstract class BaseBooleanValueObject(bool value) : BaseValueObject<bool>(value)
  {
    public override void Validate()
    {
      Errors = [];
      if (!(Value == false || Value == true))
      {
        AddError(new ErrorValueObject(Name, $"{Name} is required"));
      }
    }
  }
}
