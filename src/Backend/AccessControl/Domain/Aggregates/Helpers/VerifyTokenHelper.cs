using System.Text.RegularExpressions;
using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.Utils;
using AccessControl.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Common.Enums;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.ValueObjects;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal partial class VerifyTokenHelper
    : BaseHelper,
      IHelper<VerifyTokenDomainRequest, VerifyTokenDomainResponse>
  {
    [GeneratedRegex(@"[^/]+$")]
    private static partial Regex ExtractNameFile();

    public static Result<VerifyTokenDomainResponse> Execute(VerifyTokenDomainRequest request)
    {
      var record = GetTokenRecord(request);
      var resultValidation = ValidateRecordFields(record);
      if (resultValidation.IsFailure)
      {
        return Response<VerifyTokenDomainResponse>.Failure(
          resultValidation.Message,
          resultValidation.Code,
          resultValidation.Details
        );
      }

      var jwt = new JwtHandler(record.PrivateKeyPath.Value, record.PublicKeyPath.Value);
      if (!jwt.VerifyToken(record.Token.Value))
      {
        return Response<VerifyTokenDomainResponse>.Failure(
          "Invalid token",
          ErrorEnum.BAD_REQUEST,
          new ErrorValueObject("token", "Invalid token")
        );
      }

      var data = jwt.DecodeToken(record.Token.Value);
      if (IsTokenExpired(data.Expiration))
      {
        return Response<VerifyTokenDomainResponse>.Failure(
          "Expired token",
          ErrorEnum.BAD_REQUEST,
          new ErrorValueObject("token", "Expired token")
        );
      }

      return Response<VerifyTokenDomainResponse>.Success(
        new VerifyTokenDomainResponse
        {
          Email = data.Email,
          Photo = ExtractNameFile().Match(data.Photo).Value,
          Roles = data.Roles
        }
      );
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
      var epoch = DateTime.UnixEpoch;
      var expirationDate = epoch.AddMilliseconds(expiration * 1000);
      return DateTime.UtcNow >= expirationDate;
    }
  }
}
