using AccessControl.Application.Interfaces;
using AccessControl.Infrastructure.AntiCorruption.Interfaces;
using AccessControl.Infrastructure.Persistence.Models;

namespace AccessControl.Infrastructure.Services.Helpers.Base
{
  public abstract class BaseHelperServiceInfrastructure
  {
    protected static IApplication<UserModel, RoleModel> Application;
    protected static IInfrastructureToApplication AclInputMapper;
    protected static IApplicationToInfrastructure AclOutputMapper;

    public static void SetApplication(IApplication<UserModel, RoleModel> application)
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
