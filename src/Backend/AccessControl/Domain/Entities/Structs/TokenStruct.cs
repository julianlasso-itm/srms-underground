using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities.Structs
{
  public struct TokenStruct
  {
    public TokenIdValueObject TokenId { get; set; }
    public JwtValueObject Jwt { get; set; }
    public required FullNameValueObject FullName { get; set; }
    public required EmailValueObject Email { get; set; }
    public required PhotoValueObject Photo { get; set; }
    public ExpirationValueObject Expiration { get; set; }
    public required SecretKeyValueObject SecretKey { get; set; }
  }
}
