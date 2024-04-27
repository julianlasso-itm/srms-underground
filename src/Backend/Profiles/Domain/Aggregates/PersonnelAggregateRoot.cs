using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Helpers;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Domain.Aggregate.Base;
using Shared.Domain.Events.Interfaces;

namespace Profiles.Domain.Aggregates;

public class PersonnelAggregateRoot : BaseAggregateRoot, IPersonnelAggregateRoot
{
    public IAccountAggregate AccountAggregate { get; init; }

    public PersonnelAggregateRoot(IEvent eventInterface)
        : base(eventInterface) { }

    public RegisterSkillDomainResponse RegisterSkill(RegisterSkillDomainRequest skillData)
    {
        return RegisterSkillHelper.Execute(skillData);
    }

    public DeleteSkillDomainResponse DeleteSkill(DeleteSkillDomainRequest dataDeleteRole)
    {
        return DeleteSkillHelper.Execute(dataDeleteRole);
    }

    public UpdateSkillDomainResponse UpdateSkill(UpdateSkillDomainRequest dataUpdateSkill)
    {
        return UpdateSkillHelper.Execute(dataUpdateSkill);
    }

    public RegisterProfessionalDomainResponse RegisterProfessional(RegisterProfessionalDomainRequest dataRegisterProfessional)
    {
        return RegisterProfessionalHelper.Execute(dataRegisterProfessional);
    }

    public DeleteProfessionalDomainResponse DeleteProfessional(DeleteProfessionalDomainRequest dataDeleteProfessional)
    {
        return DeleteProfessionalHelper.Execute(dataDeleteProfessional);
    }

    public UpdateProfessionalDomainResponse UpdateProfessional(UpdateProfessionalDomainRequest dataUpdateProfessional)
    {
        return UpdateProfessionalHelper.Execute(dataUpdateProfessional);
    }

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
