using Shared.Domain.ValueObjects;

namespace Shared.Domain.Exceptions
{
  public class DomainException : Exception
  {
    public List<ErrorValueObject> DomainErrors { get; protected set; } = [];

    public DomainException(string message, List<ErrorValueObject> errors)
      : base(message)
    {
      DomainErrors = errors;
    }

    public DomainException(string message, List<ErrorValueObject> errors, Exception innerException)
      : base(message, innerException)
    {
      DomainErrors = errors;
    }
  }
}
