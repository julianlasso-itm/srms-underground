using AccessControl.Application;
using AccessControl.Infrastructure.Persistence.Models;

namespace AccessControl.Infrastructure.Services.Helpers.Base
{
  public abstract class BaseHelperServiceInfrastructure
  {
    protected static Application<RoleModel> Application;

    public static void SetApplication(Application<RoleModel> application)
    {
      Application = application;
    }
  }
}
