namespace Shared.Domain.ValueObjects;

public class ErrorValueObject
{
    public string Field { get; }
    public string Message { get; }

    public ErrorValueObject(string field, string message)
    {
        Field = field;
        Message = message;
    }
}
