using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Interfaces;

public interface IPersonnelAggregateRoot : IAggregateRoot {

    public RegisterSkillDomainResponse RegisterSkill(RegisterSkillDomainRequest skillData);
}
