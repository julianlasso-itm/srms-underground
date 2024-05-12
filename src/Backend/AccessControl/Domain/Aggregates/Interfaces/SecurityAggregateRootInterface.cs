using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Interfaces
{
  public interface ISecurityAggregateRoot : IAggregateRoot
  {
    public RegisterCredentialDomainResponse RegisterCredential(
      RegisterCredentialDomainRequest registerData
    );
    public RegisterRoleDomainResponse RegisterRole(RegisterRoleDomainRequest registerData);
    public UpdateRoleDomainResponse UpdateRole(UpdateRoleDomainRequest updateData);
    public DeleteRoleDomainResponse DeleteRole(DeleteRoleDomainRequest deleteData);
    public ActivateTokenDomainResponse ValidateActivationToken(
      ActivateTokenDomainRequest activateData
    );
    public ActiveCredentialDomainResponse ActiveCredential(
      ActiveCredentialDomainRequest activeData
    );
  }
}
