using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.Utils;
using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities
{
  internal sealed class TokenEntity
  {
    private const int ExpirationInHours = 1;
    public JwtValueObject Jwt { get; internal set; }
    public PrivateKeyPathValueObject PrivateKeyPath { get; internal set; }
    public PublicKeyPathValueObject PublicKeyPath { get; internal set; }

    public TokenEntity() { }

    public TokenEntity(TokenStruct data)
    {
      Jwt = data.Jwt;
      PrivateKeyPath = data.PrivateKeyPath;
      PublicKeyPath = data.PublicKeyPath;
    }

    public void Register(FullNameValueObject name, EmailValueObject email, PhotoValueObject photo)
    {
      var jwt = new JwtHandler(PrivateKeyPath.Value, PublicKeyPath.Value);
      var jwtPayload = new JwtPayload
      {
        TokenId = new TokenIdValueObject(Guid.NewGuid().ToString()).Value,
        Name = name.Value,
        Email = email.Value,
        Photo = photo.Value,
        Expiration = new ExpirationValueObject(GetExpirationInMilliseconds()).Value
      };
      Jwt = new JwtValueObject(jwt.GenerateToken(jwtPayload));
    }

    private static long GetExpirationInMilliseconds()
    {
      var expirationTime = DateTime.UtcNow.AddHours(ExpirationInHours);
      var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      return (long)(expirationTime - unixEpoch).TotalSeconds;
    }
  }
}
