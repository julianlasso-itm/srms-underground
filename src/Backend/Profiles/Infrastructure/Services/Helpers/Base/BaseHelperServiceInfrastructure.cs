using Profiles.Application;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Services.Helpers.Base
{
  public abstract class BaseHelperServiceInfrastructure
  {
    protected static Application<
      CountryModel,
      ProvinceModel,
      CityModel,
      RoleModel,
      SkillModel,
      ProfessionalModel
    > Application;

    public static void SetApplication(
      Application<
        CountryModel,
        ProvinceModel,
        CityModel,
        RoleModel,
        SkillModel,
        ProfessionalModel
      > application
    )
    {
      Application = application;
    }
  }
}
