using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Helpers;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Events.Interfaces;

namespace Profiles.Domain.Aggregates
{
  public class PersonnelAggregateRoot(IEvent eventHandler)
    : BaseAggregateRoot(eventHandler),
      IPersonnelAggregateRoot
  {
    private AccountAggregate AccountAggregate { get; init; } = new AccountAggregate();

    public Result<DeleteCityDomainResponse> DeleteCity(DeleteCityDomainRequest request)
    {
      return AccountAggregate.DeleteCity(request);
    }

    public Result<DeleteCountryDomainResponse> DeleteCountry(DeleteCountryDomainRequest request)
    {
      return AccountAggregate.DeleteCountry(request);
    }

    public Result<DeleteLevelDomainResponse> DeleteLevel(DeleteLevelDomainRequest request)
    {
      return DeleteLevelHelper.Execute(request);
    }

    public Result<DeleteProfessionalDomainResponse> DeleteProfessional(
      DeleteProfessionalDomainRequest dataDeleteProfessional
    )
    {
      return DeleteProfessionalHelper.Execute(dataDeleteProfessional);
    }

    public Result<DeleteProvinceDomainResponse> DeleteProvince(DeleteProvinceDomainRequest request)
    {
      return AccountAggregate.DeleteProvince(request);
    }

    public Result<DeleteRoleDomainResponse> DeleteRole(DeleteRoleDomainRequest dataDeleteRole)
    {
      return DeleteRoleHelper.Execute(dataDeleteRole);
    }

    public Result<DeleteSkillDomainResponse> DeleteSkill(DeleteSkillDomainRequest dataDeleteSkill)
    {
      return DeleteSkillHelper.Execute(dataDeleteSkill);
    }

    public Result<RegisterCityDomainResponse> RegisterCity(RegisterCityDomainRequest request)
    {
      return AccountAggregate.RegisterCity(request);
    }

    public Result<RegisterCountryDomainResponse> RegisterCountry(
      RegisterCountryDomainRequest request
    )
    {
      return AccountAggregate.RegisterCountry(request);
    }

    public Result<RegisterLevelDomainResponse> RegisterLevel(RegisterLevelDomainRequest request)
    {
      return RegisterLevelHelper.Execute(request);
    }

    public Result<RegisterProfessionalDomainResponse> RegisterProfessional(
      RegisterProfessionalDomainRequest dataRegisterProfessional
    )
    {
      return RegisterProfessionalHelper.Execute(dataRegisterProfessional);
    }

    public Result<RegisterProvinceDomainResponse> RegisterProvince(
      RegisterProvinceDomainRequest request
    )
    {
      return AccountAggregate.RegisterProvince(request);
    }

    public Result<RegisterRoleDomainResponse> RegisterRole(RegisterRoleDomainRequest roleData)
    {
      return RegisterRoleHelper.Execute(roleData);
    }

    public Result<RegisterSkillDomainResponse> RegisterSkill(RegisterSkillDomainRequest skillData)
    {
      return RegisterSkillHelper.Execute(skillData);
    }

    public Result<UpdateCityDomainResponse> UpdateCity(UpdateCityDomainRequest request)
    {
      return AccountAggregate.UpdateCity(request);
    }

    public Result<UpdateCountryDomainResponse> UpdateCountry(UpdateCountryDomainRequest request)
    {
      return AccountAggregate.UpdateCountry(request);
    }

    public Result<UpdateLevelDomainResponse> UpdateLevel(UpdateLevelDomainRequest request)
    {
      return UpdateLevelHelper.Execute(request);
    }

    public Result<UpdateProfessionalDomainResponse> UpdateProfessional(
      UpdateProfessionalDomainRequest dataUpdateProfessional
    )
    {
      return UpdateProfessionalHelper.Execute(dataUpdateProfessional);
    }

    public Result<UpdateProvinceDomainResponse> UpdateProvince(UpdateProvinceDomainRequest request)
    {
      return AccountAggregate.UpdateProvince(request);
    }

    public Result<UpdateRoleDomainResponse> UpdateRole(UpdateRoleDomainRequest dataUpdateRole)
    {
      return UpdateRoleHelper.Execute(dataUpdateRole);
    }

    public Result<UpdateSkillDomainResponse> UpdateSkill(UpdateSkillDomainRequest dataUpdateSkill)
    {
      return UpdateSkillHelper.Execute(dataUpdateSkill);
    }
  }
}
