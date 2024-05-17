using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities.Records;

internal record CredentialRecord
{
  public CredentialIdValueObject CredentialId { get; set; }
  public FullNameValueObject Name { get; set; }
  public EmailValueObject Email { get; set; }
  public PasswordValueObject Password { get; set; }
  public AvatarValueObject Avatar { get; set; }
  public DisabledValueObject Disabled { get; set; }
}
