using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class PasswordRecoveryHelper
    : BaseHelper,
      IHelper<PasswordRecoveryDomainRequest, PasswordRecoveryDomainResponse>
  {
    public static PasswordRecoveryDomainResponse Execute(PasswordRecoveryDomainRequest request)
    {
      var @struct = GetCredentialStruct(request);
      ValidateStructureFields(@struct);
      return MapStructToResponse(@struct);
    }

    private static CredentialStruct GetCredentialStruct(PasswordRecoveryDomainRequest request)
    {
      return new CredentialStruct { Email = new EmailValueObject(request.Email) };
    }

    private static PasswordRecoveryDomainResponse MapStructToResponse(CredentialStruct credential)
    {
      return new PasswordRecoveryDomainResponse { Email = credential.Email.Value };
    }
  }
}
