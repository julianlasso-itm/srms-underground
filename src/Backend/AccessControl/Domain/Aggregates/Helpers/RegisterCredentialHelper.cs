using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers;

internal abstract class RegisterCredentialHelper
  : BaseHelper,
    IHelper<RegisterCredentialDomainRequest, RegisterCredentialDomainResponse>
{
  private const string AvatarExtension = ".webp";

  public static RegisterCredentialDomainResponse Execute(
    RegisterCredentialDomainRequest registerData
  )
  {
    var @struct = GetCredentialStruct(registerData);
    ValidateStructureFields(@struct);

    var credential = new CredentialEntity();
    credential.Register(@struct.Name, @struct.Email, @struct.Password, @struct.Avatar);

    return new RegisterCredentialDomainResponse
    {
      CredentialId = credential.CredentialId.Value,
      Name = credential.Name.Value,
      Email = credential.Email.Value,
      Password = credential.Password.Value,
      Avatar = credential.Avatar.Value,
      AvatarExtension = AvatarExtension,
      Photo = "",
      Disabled = credential.Disabled.Value,
    };
  }

  private static CredentialStruct GetCredentialStruct(RegisterCredentialDomainRequest registerData)
  {
    var name = new FullNameValueObject(registerData.Name);
    var email = new EmailValueObject(registerData.Email);
    var password = new PasswordValueObject(registerData.Password);
    var avatar = new AvatarValueObject(registerData.Avatar);
    return new CredentialStruct
    {
      Name = name,
      Email = email,
      Password = password,
      Avatar = avatar,
    };
  }
}
