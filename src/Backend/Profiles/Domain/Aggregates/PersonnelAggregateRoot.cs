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
}
