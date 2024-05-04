using QueryBank.Infrastructure.AntiCorruption.Interfaces;

namespace QueryBank.Infrastructure.AntiCorruption
{
  public class InfrastructureToApplication : IInfrastructureToApplication
  {
    private static InfrastructureToApplication s_instance;

    public static InfrastructureToApplication Instance
    {
      get
      {
        s_instance ??= new InfrastructureToApplication();
        return s_instance;
      }
    }
  }
}
