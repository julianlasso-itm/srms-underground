using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Interfaces;

public interface IPersonnelAggregateRoot : IAggregateRoot
{
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
