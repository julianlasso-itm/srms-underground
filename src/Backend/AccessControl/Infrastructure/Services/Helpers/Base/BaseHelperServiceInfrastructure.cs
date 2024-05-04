using AccessControl.Application;
using AccessControl.Infrastructure.AntiCorruption.Interfaces;
using AccessControl.Infrastructure.Persistence.Models;

namespace AccessControl.Infrastructure.Services.Helpers.Base
{
  public abstract class BaseHelperServiceInfrastructure
  {
    protected static Application<RoleModel> Application;
    protected static IInfrastructureToApplication AclInputMapper;
    protected static IApplicationToInfrastructure AclOutputMapper;

    public static void SetApplication(Application<RoleModel> application)
    {
      Application = application;
    }

    public static void SetAntiCorruptionLayer(IAntiCorruptionLayer antiCorruptionLayer)
    {
      AclInputMapper = antiCorruptionLayer.GetInfrastructureToApplication();
      AclOutputMapper = antiCorruptionLayer.GetApplicationToInfrastructure();
    }
  }
}
