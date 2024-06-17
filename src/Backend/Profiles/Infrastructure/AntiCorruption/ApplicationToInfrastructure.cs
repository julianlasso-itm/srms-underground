using Profiles.Infrastructure.AntiCorruption.Interfaces;

namespace Profiles.Infrastructure.AntiCorruption
{
  public class ApplicationToInfrastructure : IApplicationToInfrastructure
  {
    private static ApplicationToInfrastructure s_instance;

    public static ApplicationToInfrastructure Instance
    {
      get
      {
        s_instance ??= new ApplicationToInfrastructure();
        return s_instance;
      }
    }
  }
}
