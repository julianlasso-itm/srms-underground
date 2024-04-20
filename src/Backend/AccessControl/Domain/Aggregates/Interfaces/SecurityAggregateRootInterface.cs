using AccessControl.Domain.Aggregates.Dto.Request;
using AccessControl.Domain.Aggregates.Dto.Response;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Interfaces;

public interface ISecurityAggregateRoot : IAggregate
{
    public RegisterCredentialDomainResponse RegisterCredential(
        RegisterCredentialDomainRequest registerData
    );
    public RegisterRoleDomainResponse RegisterRole(RegisterRoleDomainRequest registerData);
    public UpdateRoleDomainResponse UpdateRole(UpdateRoleDomainRequest updateData);
    public DeleteRoleDomainResponse DeleteRole(DeleteRoleDomainRequest deleteData);
}
