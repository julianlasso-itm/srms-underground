using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Shared.Common;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Interfaces
{
  public interface IPersonnelAggregateRoot : IAggregateRoot, IAccountAggregate
  {
    public Result<DeleteRoleDomainResponse> DeleteRole(DeleteRoleDomainRequest dataDeleteRole);
    public Result<RegisterRoleDomainResponse> RegisterRole(RegisterRoleDomainRequest roleData);
    public Result<UpdateRoleDomainResponse> UpdateRole(UpdateRoleDomainRequest dataUpdateRole);
    public Result<DeleteSkillDomainResponse> DeleteSkill(DeleteSkillDomainRequest dataDeleteSkill);
    public Result<RegisterSkillDomainResponse> RegisterSkill(RegisterSkillDomainRequest skillData);
    public Result<UpdateSkillDomainResponse> UpdateSkill(UpdateSkillDomainRequest dataUpdateSkill);
    public Result<RegisterProfessionalDomainResponse> RegisterProfessional(
      RegisterProfessionalDomainRequest dataRegisterProfessional
    );
    public Result<DeleteProfessionalDomainResponse> DeleteProfessional(
      DeleteProfessionalDomainRequest dataDeleteProfessional
    );
    public Result<UpdateProfessionalDomainResponse> UpdateProfessional(
      UpdateProfessionalDomainRequest dataUpdateProfessional
    );
    public Result<RegisterLevelDomainResponse> RegisterLevel(RegisterLevelDomainRequest request);
    public Result<UpdateLevelDomainResponse> UpdateLevel(UpdateLevelDomainRequest request);
    public Result<DeleteLevelDomainResponse> DeleteLevel(DeleteLevelDomainRequest request);
  }
}
