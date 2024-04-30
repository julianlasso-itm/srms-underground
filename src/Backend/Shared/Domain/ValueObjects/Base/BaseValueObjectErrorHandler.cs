namespace Shared.Domain.ValueObjects.Base
{
  public abstract class BaseValueObjectErrorHandler
  {
    public List<ErrorValueObject> Errors { get; protected set; }
    public string ErrorMessage { get; set; }

    public BaseValueObjectErrorHandler()
    {
      Errors = new List<ErrorValueObject>();
      ErrorMessage = "There are some errors in the data provided";
    }

    public bool IsValid()
    {
      return !HasErrors();
    }

    public void AddError(ErrorValueObject error)
    {
      Errors.Add(error);
    }

    private bool HasErrors()
    {
      return Errors.Count > 0;
    }

    public abstract void Validate();
  }
}
