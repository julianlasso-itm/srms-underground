using AccessControl.Domain.Aggregates.Dto;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Interfaces;

public interface ISecurityAggregateRoot : IAggregate
{
    public RegisterCredentialResponse RegisterCredential(RegisterCredential registerData);
    public RegisterRoleResponse RegisterRole(RegisterRole registerData);
    public UpdateRoleResponse UpdateRole(UpdateRole updateData);
    public DeleteRole DeleteRole(DeleteRole deleteData);
}
