using AccessControl.Domain.Aggregates.Dto;

namespace AccessControl.Domain.Aggregates.Interfaces;

public interface ISecurityAggregateRoot
{
    public RegisterCredentialResponse RegisterCredential(RegisterCredential registerData);
    public void EmitEvent(string channel, string data);
}
