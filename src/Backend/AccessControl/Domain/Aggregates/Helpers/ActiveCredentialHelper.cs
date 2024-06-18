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
  internal class ActiveCredentialHelper : BaseHelper, IHelper<ActiveCredentialDomainRequest>
  {
    public static Result Execute(ActiveCredentialDomainRequest data)
    {
      var record = GetCredentialRecord(data);

      var resultValidation = ValidateRecordFields(record);
      if (resultValidation.IsFailure)
      {
        return resultValidation;
      }

      var credential = ActiveCredential(record);

      return new SuccessResult<ActiveCredentialDomainResponse>(MapToResponse(credential));
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
