using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects;

public sealed class CredentialIdValueObject : BaseIdValueObject
{
  public CredentialIdValueObject(string value)
    : base(value)
  {
    Name = "CredentialId";
    Validate();
  }
}
