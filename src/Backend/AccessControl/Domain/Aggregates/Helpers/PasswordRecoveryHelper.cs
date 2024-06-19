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
  internal class PasswordRecoveryHelper
    : BaseHelper,
      IHelper<PasswordRecoveryDomainRequest, PasswordRecoveryDomainResponse>
  {
    public static Result<PasswordRecoveryDomainResponse> Execute(
      PasswordRecoveryDomainRequest request
    )
    {
      var record = GetCredentialRecord(request);

      var resultValidation = ValidateRecordFields(record);
      if (resultValidation.IsFailure)
      {
        return Response<PasswordRecoveryDomainResponse>.Failure(
          resultValidation.Message,
          resultValidation.Code,
          resultValidation.Details
        );
      }

      return Response<PasswordRecoveryDomainResponse>.Success(MapStructToResponse(record));
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
