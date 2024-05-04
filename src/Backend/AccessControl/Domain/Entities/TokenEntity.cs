using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities
{
  internal sealed class TokenEntity
  {
    private const string Format = "yyyy-MM-dd HH:mm:ss.ffffff zzz";
    public TokenIdValueObject TokenId { get; internal set; }
    public JwtValueObject Jwt { get; internal set; }
    public FullNameValueObject FullName { get; internal set; }
    public EmailValueObject Email { get; internal set; }
    public PhotoValueObject Photo { get; internal set; }
    public ExpirationValueObject Expiration { get; internal set; }

    public TokenEntity() { }

    public TokenEntity(TokenStruct data)
    {
      TokenId = data.TokenId;
      Jwt = data.Jwt;
      FullName = data.FullName;
      Email = data.Email;
      Photo = data.Photo;
      Expiration = data.Expiration;
    }

    public void Register(
      FullNameValueObject fullName,
      EmailValueObject email,
      PhotoValueObject photo
    )
    {
      TokenId = new TokenIdValueObject(Guid.NewGuid().ToString());
      // Jwt = jwt; // TODO: Implement JWT generation
      FullName = fullName;
      Email = email;
      Photo = photo;
      Expiration = new ExpirationValueObject(DateTime.UtcNow.AddHours(1).ToString(Format));
    }
  }
}
