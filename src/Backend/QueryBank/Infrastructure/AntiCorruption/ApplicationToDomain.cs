using QueryBank.Application.AntiCorruption.Interfaces;

namespace QueryBank.Infrastructure.AntiCorruption
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
