using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class ChangePasswordHelper
    : BaseHelper,
      IHelper<ChangePasswordDomainRequest, ChangePasswordDomainResponse>
  {
    public static ChangePasswordDomainResponse Execute(ChangePasswordDomainRequest data)
    {
      var record = GetUpdatePasswordRecord(data);
      ValidateRecordFields(record);
      var credential = new CredentialEntity(
        new CredentialRecord { CredentialId = record.CredentialId }
      );
      credential.UpdatePassword(record.NewPassword);
      return MapToResponse(credential, record.OldPassword.Value);
    }

    private static UpdatePasswordRecord GetUpdatePasswordRecord(ChangePasswordDomainRequest data)
    {
      return new UpdatePasswordRecord
      {
        CredentialId = new CredentialIdValueObject(data.CredentialId),
        OldPassword = new PasswordValueObject(data.OldPassword, false),
        NewPassword = new PasswordValueObject(data.NewPassword),
      };
    }

    private static ChangePasswordDomainResponse MapToResponse(
      CredentialEntity credential,
      string oldPassword
    )
    {
      return new ChangePasswordDomainResponse
      {
        CredentialId = credential.CredentialId.Value,
        OldPassword = oldPassword,
        NewPassword = credential.Password.Value,
      };
    }
  }
}
