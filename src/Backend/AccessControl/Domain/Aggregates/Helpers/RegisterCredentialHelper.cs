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
    public static RegisterCredentialDomainResponse Execute(RegisterCredentialDomainRequest request)
    {
        var @struct = GetCredentialStruct(request);
        ValidateStructureFields(@struct);

        var credential = new CredentialEntity();
        credential.Register(@struct.Email, @struct.Password);

        return new RegisterCredentialDomainResponse
        {
            CredentialId = credential.CredentialId.Value,
            Email = credential.Email.Value,
            Password = credential.Password.Value,
            Disabled = credential.Disabled.Value,
        };
    }

    private static CredentialStruct GetCredentialStruct(RegisterCredentialDomainRequest request)
    {
        var email = new EmailValueObject(request.Email);
        var password = new PasswordValueObject(request.Password);
        return new CredentialStruct { Email = email, Password = password };
    }
}
