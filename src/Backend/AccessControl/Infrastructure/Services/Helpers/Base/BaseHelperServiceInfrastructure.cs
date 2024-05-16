using AccessControl.Application.Interfaces;
using AccessControl.Infrastructure.AntiCorruption.Interfaces;
using AccessControl.Infrastructure.Persistence.Models;
using Shared.Application.Interfaces;

namespace AccessControl.Infrastructure.Services.Helpers.Base
{
  public abstract class BaseHelperServiceInfrastructure
  {
    protected static IApplication<UserModel, RoleModel> Application;
    protected static IInfrastructureToApplication AclInputMapper;
    protected static IApplicationToInfrastructure AclOutputMapper;
    protected static IEnvironment Configuration;

    public static void SetApplication(IApplication<UserModel, RoleModel> application)
    {
      Application = application;
    }

    public static void SetAntiCorruptionLayer(IAntiCorruptionLayer antiCorruptionLayer)
    {
      AclInputMapper = antiCorruptionLayer.GetInfrastructureToApplication();
      AclOutputMapper = antiCorruptionLayer.GetApplicationToInfrastructure();
    }

    public static void SetEnvironments(IEnvironment configuration)
    {
      Configuration = configuration;
    }
  }
}
