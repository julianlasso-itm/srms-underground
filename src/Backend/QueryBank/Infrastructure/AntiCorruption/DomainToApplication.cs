using QueryBank.Application.AntiCorruption.Interfaces;

namespace QueryBank.Infrastructure.AntiCorruption
{
  public class DomainToApplication : IDomainToApplication
  {
    private static DomainToApplication s_instance;

    public static DomainToApplication Instance
    {
      get
      {
        s_instance ??= new DomainToApplication();
        return s_instance;
      }
    }
  }
}
