using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class ActiveCredentialHelper
    : BaseHelper,
      IHelper<ActiveCredentialDomainRequest, ActiveCredentialDomainResponse>
  {
    public static ActiveCredentialDomainResponse Execute(ActiveCredentialDomainRequest data)
    {
      var @struct = GetCredentialStruct(data);
      ValidateStructureFields(@struct);
      var credential = ActiveCredential(@struct);
      return MapToResponse(credential);
    }

    private static CredentialStruct GetCredentialStruct(ActiveCredentialDomainRequest data)
    {
      return new CredentialStruct { CredentialId = new CredentialIdValueObject(data.UserId) };
    }

    private static CredentialEntity ActiveCredential(CredentialStruct @struct)
    {
      var credential = new CredentialEntity(@struct);
      credential.Enable();
      return credential;
    }

    private static ActiveCredentialDomainResponse MapToResponse(CredentialEntity credential)
    {
      return new ActiveCredentialDomainResponse
      {
        UserId = credential.CredentialId.Value,
        Disabled = credential.Disabled.Value,
      };
    }
  }
}
