namespace AccessControl.Infrastructure.AntiCorruption
{
  public class DomainToApplication
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
