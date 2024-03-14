namespace Shared.Domain.ValueObjects;

public class ErrorValueObject
{
    string Field { get; }
    string Message { get; }

    public ErrorValueObject(string field, string message)
    {
        Field = field;
        Message = message;
    }
}
