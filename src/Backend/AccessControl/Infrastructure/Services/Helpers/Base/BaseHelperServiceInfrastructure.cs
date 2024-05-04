using AccessControl.Application;
using AccessControl.Infrastructure.AntiCorruption.Interfaces;
using AccessControl.Infrastructure.Persistence.Models;

namespace AccessControl.Infrastructure.Services.Helpers.Base
{
  public abstract class BaseHelperServiceInfrastructure
  {
    protected static Application<RoleModel> Application;
    protected static IAntiCorruptionLayer AntiCorruptionLayer;

    public static void SetApplication(Application<RoleModel> application)
    {
      Application = application;
    }

    public static void SetAntiCorruptionLayer(IAntiCorruptionLayer antiCorruptionLayer)
    {
      AntiCorruptionLayer = antiCorruptionLayer;
    }
  }
}
