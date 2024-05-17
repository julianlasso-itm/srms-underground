using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Structs;
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
      var @struct = GetUpdatePasswordStruct(data);
      ValidateStructureFields(@struct);
      var credential = new CredentialEntity(
        new CredentialStruct { CredentialId = @struct.CredentialId }
      );
      credential.UpdatePassword(@struct.NewPassword);
      return MapToResponse(credential, @struct.OldPassword.Value);
    }

    private static UpdatePasswordStruct GetUpdatePasswordStruct(ChangePasswordDomainRequest data)
    {
      return new UpdatePasswordStruct
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
