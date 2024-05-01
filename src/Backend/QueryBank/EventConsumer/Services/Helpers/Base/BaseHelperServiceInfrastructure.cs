using QueryBank.Application;
using QueryBank.Infrastructure.Persistence.Models;

namespace QueryBank.EventConsumer.Services.Helpers.Base
{
  public abstract class BaseHelperServiceInfrastructure
  {
    protected static Application<SkillModel> Application;

    public static void SetApplication(Application<SkillModel> application)
    {
      Application = application;
    }
  }
}
