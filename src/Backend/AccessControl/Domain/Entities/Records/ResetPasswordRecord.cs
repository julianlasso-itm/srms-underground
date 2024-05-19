using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities.Records
{
  public record ResetPasswordRecord
  {
    public PasswordValueObject Password { get; init; }
  }
}
