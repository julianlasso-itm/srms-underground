using AccessControl.Domain.Aggregates.Dto;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Interfaces;

public interface ISecurityAggregateRoot : IAggregate
{
    public RegisterCredentialResponse RegisterCredential(RegisterCredentialRequest registerData);
    public RegisterRoleResponse RegisterRole(RegisterRoleRequest registerData);
    public UpdateRoleResponse UpdateRole(UpdateRoleRequest updateData);
    public DeleteRoleResponse DeleteRole(DeleteRoleRequest deleteData);
}
