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
  internal class RegisterCredentialHelper
    : BaseHelper,
      IHelper<RegisterCredentialDomainRequest, RegisterCredentialDomainResponse>
  {
    private const string AvatarExtension = ".webp";
    private const string UserRoleId = "dce27d6c-a019-4ba6-b7fa-9b3296dfec1b";

    public static Result<RegisterCredentialDomainResponse> Execute(
      RegisterCredentialDomainRequest registerData
    )
    {
      var record = GetCredentialRecord(registerData);
      var resultValidation = ValidateRecordFields(record);

      if (resultValidation.IsFailure)
      {
        return Response<RegisterCredentialDomainResponse>.Failure(
          resultValidation.Message,
          resultValidation.Code,
          resultValidation.Details
        );
      }

      var credential = new CredentialEntity();
      credential.Register(
        record.Name,
        record.Email,
        record.Password,
        record.Avatar,
        new DisabledValueObject(true)
      );
      credential.AddRole(
        new RoleEntity(new RoleRecord { RoleId = new RoleIdValueObject(UserRoleId) })
      );

      return Response<RegisterCredentialDomainResponse>.Success(
        new RegisterCredentialDomainResponse
        {
          CredentialId = credential.CredentialId.Value,
          Name = credential.Name.Value,
          Email = credential.Email.Value,
          Password = credential.Password.Value,
          Avatar = credential.Avatar.Value,
          AvatarExtension = AvatarExtension,
          Photo = "",
          Roles = credential.Roles.Select(role => role.RoleId.Value).ToArray(),
          Disabled = credential.Disabled.Value,
        }
      );
    }

    private static CredentialRecord GetCredentialRecord(
      RegisterCredentialDomainRequest registerData
    )
    {
      var name = new FullNameValueObject(registerData.Name);
      var email = new EmailValueObject(registerData.Email);
      var password = new PasswordValueObject(registerData.Password);
      var avatar = new AvatarValueObject(registerData.Avatar);
      return new CredentialRecord
      {
        Name = name,
        Email = email,
        Password = password,
        Avatar = avatar,
      };
    }
  }
}
