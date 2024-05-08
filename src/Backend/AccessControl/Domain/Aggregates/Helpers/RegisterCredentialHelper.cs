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
  public static RegisterCredentialDomainResponse Execute(
    RegisterCredentialDomainRequest registerData
  )
  {
    var @struct = GetCredentialStruct(registerData);
    ValidateStructureFields(@struct);

    var credential = new CredentialEntity();
    credential.Register(@struct.Name, @struct.Email, @struct.Password, @struct.Photo);

    return new RegisterCredentialDomainResponse
    {
      CredentialId = credential.CredentialId.Value,
      Name = credential.Name.Value,
      Email = credential.Email.Value,
      Password = credential.Password.Value,
      Photo = credential.Photo.Value,
      Disabled = credential.Disabled.Value,
    };
  }

  private static CredentialStruct GetCredentialStruct(RegisterCredentialDomainRequest registerData)
  {
    var name = new FullNameValueObject(registerData.Name);
    var email = new EmailValueObject(registerData.Email);
    var password = new PasswordValueObject(registerData.Password);
    var photo = new PhotoValueObject(registerData.Photo);
    return new CredentialStruct
    {
      Name = name,
      Email = email,
      Password = password,
      Photo = photo,
    };
  }
}
