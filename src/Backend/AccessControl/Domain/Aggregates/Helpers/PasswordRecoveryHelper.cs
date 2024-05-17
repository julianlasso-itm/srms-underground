using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Records;
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
      var record = GetCredentialRecord(request);
      ValidateRecordFields(record);
      return MapStructToResponse(record);
    }

    private static CredentialRecord GetCredentialRecord(PasswordRecoveryDomainRequest request)
    {
      return new CredentialRecord { Email = new EmailValueObject(request.Email) };
    }

    private static PasswordRecoveryDomainResponse MapStructToResponse(CredentialRecord credential)
    {
      return new PasswordRecoveryDomainResponse { Email = credential.Email.Value };
    }
  }
}
