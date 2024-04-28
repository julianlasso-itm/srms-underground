using Profiles.Application;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Services.Helpers.Base;

public abstract class BaseHelperServiceInfrastructure
{
    protected static Application<Skill, Professional> Application;

    public static void SetApplication(Application<Skill, Professional> application)
    {
        Application = application;
    }
}
