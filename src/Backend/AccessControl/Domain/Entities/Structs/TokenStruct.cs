using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities.Structs
{
  public struct TokenStruct
  {
    public TokenIdValueObject TokenId { get; set; }
    public JwtValueObject Jwt { get; set; }
    public FullNameValueObject FullName { get; set; }
    public EmailValueObject Email { get; set; }
    public PhotoValueObject Photo { get; set; }
    public ExpirationValueObject Expiration { get; set; }
  }
}
