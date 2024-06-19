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
  internal class ValidateEmailAndEncryptPasswordHelper
    : BaseHelper,
      IHelper<SignInDataInitialsDomainRequest, SignInDataInitialsDomainResponse>
  {
    public static Result<SignInDataInitialsDomainResponse> Execute(
      SignInDataInitialsDomainRequest request
    )
    {
      var record = GetCredentialRecord(request);

      var resultValidation = ValidateRecordFields(record);
      if (resultValidation.IsFailure)
      {
        return Response<SignInDataInitialsDomainResponse>.Failure(
          resultValidation.Message,
          resultValidation.Code,
          resultValidation.Details
        );
      }

      return Response<SignInDataInitialsDomainResponse>.Success(MapToResponse(record));
    }

    private static CredentialRecord GetCredentialRecord(SignInDataInitialsDomainRequest request)
    {
      return new CredentialRecord
      {
        Email = new EmailValueObject(request.Email),
        Password = new PasswordValueObject(request.Password, false),
      };
    }

    private static SignInDataInitialsDomainResponse MapToResponse(CredentialRecord record)
    {
      return new SignInDataInitialsDomainResponse
      {
        Email = record.Email.Value,
        Password = record.Password.Value,
      };
    }
  }
}
