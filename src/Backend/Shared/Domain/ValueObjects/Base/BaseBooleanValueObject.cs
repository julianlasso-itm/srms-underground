namespace Shared.Domain.ValueObjects.Base
{
  public abstract class BaseBooleanValueObject : BaseValueObject<bool>
  {
    protected BaseBooleanValueObject(bool value)
      : base(value) { }

    public override void Validate()
    {
      Errors = new List<ErrorValueObject>();
      if (!(Value == false || Value == true))
      {
        AddError(new ErrorValueObject(Name, $"{Name} is required"));
      }
    }
  }
}
