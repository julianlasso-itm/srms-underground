using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Helpers;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Domain.Aggregate.Base;
using Shared.Domain.Events.Interfaces;

namespace Profiles.Domain.Aggregates;

public class PersonnelAggregateRoot : BaseAggregateRoot, IPersonnelAggregateRoot
{
    public PersonnelAggregateRoot(IEvent eventInterface)
        : base(eventInterface) { }

    public RegisterRoleDomainResponse RegisterRole(RegisterRoleDomainRequest roleData)
    {
        return RegisterRoleHelper.Execute(roleData);
    }

    public DeleteRoleDomainResponse DeleteRole(DeleteRoleDomainRequest dataDeleteRole)
    {
        return DeleteRoleHelper.Execute(dataDeleteRole);
    }

    public UpdateRoleDomainResponse UpdateRole(UpdateRoleDomainRequest dataUpdateRole)
    {
        return UpdateRoleHelper.Execute(dataUpdateRole);
    }
}
