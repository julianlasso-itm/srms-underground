using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using Shared.Domain.Aggregate.Interfaces;

namespace QueryBank.Domain.Aggregates.Interfaces
{
  public interface ICatalogAggregateRoot : IAggregateRoot
  {
    public DeleteSkillDomainResponse DeleteSkill(DeleteSkillDomainRequest dataDeleteSkill);
    public RegisterSkillDomainResponse RegisterSkill(RegisterSkillDomainRequest skillData);
    public UpdateSkillDomainResponse UpdateSkill(UpdateSkillDomainRequest dataUpdateSkill);
  }
}
