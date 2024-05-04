using Profiles.Application;
using Profiles.Application.Repositories;
using Profiles.Domain.Aggregates;
using Profiles.Infrastructure.AntiCorruption;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Services;

namespace Profiles.Infrastructure.Services
{
  internal class ApplicationService
  {
    private readonly Application<
      CountryModel,
      ProvinceModel,
      CityModel,
      RoleModel,
      SkillModel,
      ProfessionalModel,
      LevelModel
    > _application;

    public ApplicationService(
      SharedEventHandler eventHandler,
      ICountryRepository<CountryModel> countryRepository,
      IProvinceRepository<ProvinceModel> provinceRepository,
      ICityRepository<CityModel> cityRepository,
      IRoleRepository<RoleModel> roleRepository,
      ISkillRepository<SkillModel> skillRepository,
      IProfessionalRepository<ProfessionalModel> professionalRepository,
      ILevelRepository<LevelModel> levelRepository,
      AntiCorruptionLayerService<AntiCorruptionLayer> antiCorruptionLayerService
    )
    {
      _application = new Application<
        CountryModel,
        ProvinceModel,
        CityModel,
        RoleModel,
        SkillModel,
        ProfessionalModel,
        LevelModel
      >(
        antiCorruptionLayerService.GetAntiCorruptionLayer().GetApplicationToDomain(),
        antiCorruptionLayerService.GetAntiCorruptionLayer().GetDomainToApplication(),
        countryRepository,
        provinceRepository,
        cityRepository,
        roleRepository,
        skillRepository,
        professionalRepository,
        levelRepository
      )
      {
        AggregateRoot = new PersonnelAggregateRoot(eventHandler)
      };
    }

    public Application<
      CountryModel,
      ProvinceModel,
      CityModel,
      RoleModel,
      SkillModel,
      ProfessionalModel,
      LevelModel
    > GetApplication()
    {
      return _application;
    }
  }
}
