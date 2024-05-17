using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class RegisterCredentialHelper
    : BaseHelper,
      IHelper<RegisterCredentialDomainRequest, RegisterCredentialDomainResponse>
  {
    private const string AvatarExtension = ".webp";
    private const string UserRoleId = "137bcadf-79bb-47f4-8622-e7381c7664ae";

    public static RegisterCredentialDomainResponse Execute(
      RegisterCredentialDomainRequest registerData
    )
    {
      var record = GetCredentialRecord(registerData);
      ValidateRecordFields(record);

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

      return new RegisterCredentialDomainResponse
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
      };
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
