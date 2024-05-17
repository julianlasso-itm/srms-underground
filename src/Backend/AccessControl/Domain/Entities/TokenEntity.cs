using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.Utils;
using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities
{
  internal sealed class TokenEntity
  {
    private const int ExpirationInHours = 8;
    public JwtValueObject Jwt { get; internal set; }
    public PrivateKeyPathValueObject PrivateKeyPath { get; internal set; }
    public PublicKeyPathValueObject PublicKeyPath { get; internal set; }

    public TokenEntity() { }

    public TokenEntity(TokenRecord data)
    {
      Jwt = data.Jwt;
      PrivateKeyPath = data.PrivateKeyPath;
      PublicKeyPath = data.PublicKeyPath;
    }

    public void Register(
      FullNameValueObject name,
      EmailValueObject email,
      PhotoValueObject photo,
      List<RoleRecord> roles
    )
    {
      var jwt = new JwtHandler(PrivateKeyPath.Value, PublicKeyPath.Value);
      var jwtPayload = new JwtPayload
      {
        TokenId = new TokenIdValueObject(Guid.NewGuid().ToString()).Value,
        Name = name.Value,
        Email = email.Value,
        Photo = photo.Value,
        Roles = roles.Select(role => role.Name.Value).ToList(),
        Expiration = new ExpirationValueObject(GetExpirationInSeconds()).Value
      };
      Jwt = new JwtValueObject(jwt.GenerateToken(jwtPayload));
    }

    private static long GetExpirationInSeconds()
    {
      var expirationTime = DateTime.UtcNow.AddHours(ExpirationInHours);
      var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      return (long)(expirationTime - unixEpoch).TotalSeconds;
    }
  }
}
