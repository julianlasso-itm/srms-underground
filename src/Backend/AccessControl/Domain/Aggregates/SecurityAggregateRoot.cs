using AccessControl.Domain.Aggregates.Dto;
using AccessControl.Domain.Aggregates.Helpers;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Domain.Aggregate.Base;
using Shared.Domain.Events.Interfaces;

namespace AccessControl.Domain.Aggregates;

public class SecurityAggregateRoot : BaseAggregate, ISecurityAggregateRoot
{
    public SecurityAggregateRoot(IEvent eventInterface)
        : base(eventInterface) { }

    public RegisterCredentialResponse RegisterCredential(RegisterCredentialRequest registerData)
    {
        return RegisterCredentialHelper.Execute(registerData);
    }

    public RegisterRoleResponse RegisterRole(RegisterRoleRequest registerData)
    {
        return RegisterRoleHelper.Execute(registerData);
    }

    public UpdateRoleResponse UpdateRole(UpdateRole updateData)
    {
        return UpdateRoleHelper.Execute(updateData);
    }

    public DeleteRole DeleteRole(DeleteRole deleteData)
    {
        return DeleteRoleHelper.Execute(deleteData);
    }
}
