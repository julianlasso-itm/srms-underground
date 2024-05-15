using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  public class ValidateEmailAndEncryptPasswordHelper
    : BaseHelper,
      IHelper<SignInDataInitialsDomainRequest, SignInDataInitialsDomainResponse>
  {
    public static SignInDataInitialsDomainResponse Execute(SignInDataInitialsDomainRequest request)
    {
      var @struct = GetCredentialStruct(request);
      ValidateStructureFields(@struct);
      return MapToResponse(@struct);
    }

    private static CredentialStruct GetCredentialStruct(SignInDataInitialsDomainRequest request)
    {
      return new CredentialStruct
      {
        Email = new EmailValueObject(request.Email),
        Password = new PasswordValueObject(request.Password, false),
      };
    }

    private static SignInDataInitialsDomainResponse MapToResponse(CredentialStruct @struct)
    {
      return new SignInDataInitialsDomainResponse
      {
        Email = @struct.Email.Value,
        Password = @struct.Password.Value,
      };
    }
  }
}
