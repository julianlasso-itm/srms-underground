using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Records;
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
      var record = GetCredentialRecord(data);
      ValidateRecordFields(record);
      var credential = ActiveCredential(record);
      return MapToResponse(credential);
    }

    private static CredentialRecord GetCredentialRecord(ActiveCredentialDomainRequest data)
    {
      return new CredentialRecord { CredentialId = new CredentialIdValueObject(data.CredentialId) };
    }

    private static CredentialEntity ActiveCredential(CredentialRecord record)
    {
      var credential = new CredentialEntity(record);
      credential.Enable();
      return credential;
    }

    private static ActiveCredentialDomainResponse MapToResponse(CredentialEntity credential)
    {
      return new ActiveCredentialDomainResponse
      {
        CredentialId = credential.CredentialId.Value,
        Disabled = credential.Disabled.Value,
      };
    }
  }
}
