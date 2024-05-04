using Analytics.Application.AntiCorruption.Interfaces;

namespace Analytics.Infrastructure.AntiCorruption
{
  public class ApplicationToDomain : IApplicationToDomain
  {
    private static ApplicationToDomain s_instance;

    public static ApplicationToDomain Instance
    {
      get
      {
        s_instance ??= new ApplicationToDomain();
        return s_instance;
      }
    }
  }
}
