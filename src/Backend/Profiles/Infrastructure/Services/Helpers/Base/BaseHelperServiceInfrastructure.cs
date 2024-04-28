using Profiles.Application;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Services.Helpers.Base;

public abstract class BaseHelperServiceInfrastructure
{
    protected static Application<SkillModel, ProfessionalModel> Application;

    public static void SetApplication(Application<SkillModel, ProfessionalModel> application)
    {
        Application = application;
    }
}
