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

    public RegisterCredentialResponse RegisterCredential(RegisterCredential registerData)
    {
        var result = RegisterCredentialHelper.Execute(registerData);
        return result;
    }

    public RegisterRoleResponse RegisterRole(RegisterRole registerData)
    {
        var result = RegisterRoleHelper.Execute(registerData);
        return result;
    }

    public UpdateRoleResponse UpdateRole(UpdateRole updateData)
    {
        var result = UpdateRoleHelper.Execute(updateData);
        return result;
    }
}
