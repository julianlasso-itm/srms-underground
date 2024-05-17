using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class ValidateEmailAndEncryptPasswordHelper
    : BaseHelper,
      IHelper<SignInDataInitialsDomainRequest, SignInDataInitialsDomainResponse>
  {
    public static SignInDataInitialsDomainResponse Execute(SignInDataInitialsDomainRequest request)
    {
      var record = GetCredentialRecord(request);
      ValidateRecordFields(record);
      return MapToResponse(record);
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
