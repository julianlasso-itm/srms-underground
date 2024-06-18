using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class GenerateTokenForSignInHelper : BaseHelper, IHelper<SignInDomainRequest>
  {
    public static Result Execute(SignInDomainRequest request)
    {
      var record = TokenRecord(request);

      var resultValidation = ValidateRecordFields(record);
      if (resultValidation.IsFailure)
      {
        return resultValidation;
      }

      var token = new TokenEntity(record);
      token.Register(record.FullName, record.Email, record.Photo, record.Roles);

      return new SuccessResult<SignInDomainResponse>(
        new SignInDomainResponse { Token = token.Jwt.Value }
      );
    }

    private static TokenRecord TokenRecord(SignInDomainRequest request)
    {
      return new TokenRecord
      {
        FullName = new FullNameValueObject(request.Name),
        Email = new EmailValueObject(request.Email),
        Photo = new PhotoValueObject(request.Photo),
        Roles = request.Roles.ConvertAll(role => new RoleRecord
        {
          Name = new NameValueObject(role)
        }),
        PrivateKeyPath = new PrivateKeyPathValueObject(request.PrivateKeyPath),
        PublicKeyPath = new PublicKeyPathValueObject(request.PublicKeyPath),
      };
    }
  }
}
