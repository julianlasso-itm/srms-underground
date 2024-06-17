namespace Shared.Domain.ValueObjects
{
  public class ErrorValueObject(string field, string message)
  {
    public string Field { get; } = field;
    public string Message { get; } = message;
  }
}
