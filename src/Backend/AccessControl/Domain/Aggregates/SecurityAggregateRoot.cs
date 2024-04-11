using System.Text.Json;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Dto;
using AccessControl.Domain.Aggregates.Helpers;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Domain.Aggregate.Base;
using Shared.Domain.Events.Interfaces;

namespace AccessControl.Domain.Aggregates;

public sealed class SecurityAggregateRoot : BaseAggregate, ISecurityAggregateRoot
{
    public SecurityAggregateRoot(IEvent eventInterface)
        : base(eventInterface) { }

    public RegisterCredentialResponse RegisterCredential(RegisterCredential registerData)
    {
        var result = RegisterCredentialHelper.Execute(registerData);
        EmitEvent(
            $"{EventsConst.Prefix}.{EventsConst.EventCredentialRegistered}",
            JsonSerializer.Serialize(result)
        );
        return result;
    }

    public RegisterRoleResponse RegisterRole(RegisterRole registerData)
    {
        var result = RegisterRoleHelper.Execute(registerData);
        EmitEvent(
            $"{EventsConst.Prefix}.{EventsConst.EventRoleRegistered}",
            JsonSerializer.Serialize(result)
        );
        return result;
    }
}
