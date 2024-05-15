using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  public class GenerateTokenForSignInHelper
    : BaseHelper,
      IHelper<SignInDomainRequest, SignInDomainResponse>
  {
    public static SignInDomainResponse Execute(SignInDomainRequest request)
    {
      var @struct = TokenStruct(request);
      var token = new TokenEntity(@struct);
      token.Register(@struct.FullName, @struct.Email, @struct.Photo);
      return new SignInDomainResponse { Token = token.Jwt.Value };
    }

    private static TokenStruct TokenStruct(SignInDomainRequest request)
    {
      return new TokenStruct
      {
        FullName = new FullNameValueObject(request.Name),
        Email = new EmailValueObject(request.Email),
        Photo = new PhotoValueObject(request.Photo),
        SecretKey = new SecretKeyValueObject("secret-key"),
      };
    }
  }
}
