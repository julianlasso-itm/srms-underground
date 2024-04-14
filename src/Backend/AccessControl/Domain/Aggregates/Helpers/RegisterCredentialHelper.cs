using AccessControl.Domain.Aggregates.Dto;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers;

internal abstract class RegisterCredentialHelper
    : BaseHelper,
        IHelper<RegisterCredential, RegisterCredentialResponse>
{
    public static RegisterCredentialResponse Execute(RegisterCredential registerData)
    {
        var data = GetCredentialStruct(registerData);
        ValidateStructureFields(data);

        var credential = new CredentialEntity();
        credential.Register(data.Email, data.Password);

        return new RegisterCredentialResponse
        {
            CredentialId = credential.CredentialId.Value,
            Email = credential.Email.Value,
            Password = credential.Password.Value,
            Disabled = credential.Disabled.Value,
        };
    }

    public static void Execute()
    {
        throw new NotImplementedException();
    }

    private static CredentialStruct GetCredentialStruct(RegisterCredential registerData)
    {
        var email = new EmailValueObject(registerData.Email);
        var password = new PasswordValueObject(registerData.Password);
        return new CredentialStruct { Email = email, Password = password };
    }
}
