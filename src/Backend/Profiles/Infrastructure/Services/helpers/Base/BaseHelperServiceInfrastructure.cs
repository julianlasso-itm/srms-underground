using Profiles.Application;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Services.Helpers.Base;

public abstract class BaseHelperServiceInfrastructure
{
    protected static Application<RoleModel> Application;

    public static void SetApplication(Application<RoleModel> application)
    {
        Application = application;
    }
}