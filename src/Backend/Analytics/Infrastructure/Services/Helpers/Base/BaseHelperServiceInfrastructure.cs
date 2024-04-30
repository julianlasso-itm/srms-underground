using Analytics.Application;
using Analytics.Infrastructure.Persistence.Models;

namespace Analytics.Infrastructure.Services.Helpers.Base
{
  public abstract class BaseHelperServiceInfrastructure
  {
    protected static Application<LevelModel> Application;

    public static void SetApplication(Application<LevelModel> application)
    {
      Application = application;
    }
  }
}
