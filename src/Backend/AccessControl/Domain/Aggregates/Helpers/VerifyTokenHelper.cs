using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.Utils;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;

namespace AccessControl.Domain.Aggregates.Helpers
{
  public class VerifyTokenHelper
    : BaseHelper,
      IHelper<VerifyTokenDomainRequest, VerifyTokenDomainResponse>
  {
    public static VerifyTokenDomainResponse Execute(VerifyTokenDomainRequest request)
    {
      var @struct = GetTokenStruct(request);
      ValidateStructureFields(@struct);
      var jwt = new JwtHandler(@struct.PrivateKeyPath.Value, @struct.PublicKeyPath.Value);
      if (!jwt.VerifyToken(@struct.Token.Value))
      {
        throw new DomainException(
          "Invalid token",
          new List<ErrorValueObject> { new ErrorValueObject("token", "Invalid token") }
        );
      }
      var data = jwt.DecodeToken(@struct.Token.Value);
      if (IsTokenExpired(data.Expiration))
      {
        throw new DomainException(
          "Expired token",
          new List<ErrorValueObject> { new ErrorValueObject("token", "Expired token") }
        );
      }
      return new VerifyTokenDomainResponse { Email = data.Email, Roles = data.Roles };
    }

    private static VerifyTokenStruct GetTokenStruct(VerifyTokenDomainRequest request)
    {
      return new VerifyTokenStruct
      {
        Token = new TokenValueObject(request.Token),
        PrivateKeyPath = new PrivateKeyPathValueObject(request.PrivateKeyPath),
        PublicKeyPath = new PublicKeyPathValueObject(request.PublicKeyPath),
      };
    }

    private static bool IsTokenExpired(long expiration)
    {
      var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      var expirationDate = epoch.AddMilliseconds(expiration * 1000);
      return DateTime.UtcNow >= expirationDate;
    }
  }
}
