using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Interfaces;

public interface IPersonnelAggregateRoot : IAggregateRoot, IAccountAggregate
{
    public DeleteRoleDomainResponse DeleteRole(DeleteRoleDomainRequest dataDeleteRole);
    public RegisterRoleDomainResponse RegisterRole(RegisterRoleDomainRequest roleData);
    public UpdateRoleDomainResponse UpdateRole(UpdateRoleDomainRequest dataUpdateRole);
    public DeleteSkillDomainResponse DeleteSkill(DeleteSkillDomainRequest dataDeleteSkill);
    public RegisterSkillDomainResponse RegisterSkill(RegisterSkillDomainRequest skillData);
    public UpdateSkillDomainResponse UpdateSkill(UpdateSkillDomainRequest dataUpdateSkill);
    public RegisterProfessionalDomainResponse RegisterProfessional(
        RegisterProfessionalDomainRequest dataRegisterProfessional
    );
    public DeleteProfessionalDomainResponse DeleteProfessional(
        DeleteProfessionalDomainRequest dataDeleteProfessional
    );
    public UpdateProfessionalDomainResponse UpdateProfessional(
        UpdateProfessionalDomainRequest dataUpdateProfessional
    );
}
