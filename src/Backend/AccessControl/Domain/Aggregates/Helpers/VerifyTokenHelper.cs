using System.Text.RegularExpressions;
using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.Utils;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Exceptions;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal partial class VerifyTokenHelper
    : BaseHelper,
      IHelper<VerifyTokenDomainRequest, VerifyTokenDomainResponse>
  {
    [GeneratedRegex(@"[^/]+$")]
    private static partial Regex ExtractNameFile();

    public static VerifyTokenDomainResponse Execute(VerifyTokenDomainRequest request)
    {
      var record = GetTokenRecord(request);
      ValidateRecordFields(record);
      var jwt = new JwtHandler(record.PrivateKeyPath.Value, record.PublicKeyPath.Value);
      if (!jwt.VerifyToken(record.Token.Value))
      {
        throw new DomainException("Invalid token", [new("token", "Invalid token")]);
      }
      var data = jwt.DecodeToken(record.Token.Value);
      if (IsTokenExpired(data.Expiration))
      {
        throw new DomainException("Expired token", [new("token", "Expired token")]);
      }
      return new VerifyTokenDomainResponse
      {
        Email = data.Email,
        Photo = ExtractNameFile().Match(data.Photo).Value,
        Roles = data.Roles
      };
    }

    private static VerifyTokenRecord GetTokenRecord(VerifyTokenDomainRequest request)
    {
      return new VerifyTokenRecord
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
