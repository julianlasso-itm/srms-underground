using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class PasswordRecoveryHelper : BaseHelper, IHelper<PasswordRecoveryDomainRequest>
  {
    public static Result Execute(PasswordRecoveryDomainRequest request)
    {
      var record = GetCredentialRecord(request);

      var resultValidation = ValidateRecordFields(record);
      if (resultValidation.IsFailure)
      {
        return resultValidation;
      }

      return new SuccessResult(MapStructToResponse(record));
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
