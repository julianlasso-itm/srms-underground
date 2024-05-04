using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Infrastructure.AntiCorruption.Interfaces;

namespace AccessControl.Infrastructure.AntiCorruption
{
  public class AntiCorruptionLayer : IAntiCorruptionLayer
  {
    public IApplicationToDomain GetApplicationToDomain()
    {
      return ApplicationToDomain.Instance;
    }

    public IApplicationToInfrastructure GetApplicationToInfrastructure()
    {
      return ApplicationToInfrastructure.Instance;
    }

    public IDomainToApplication GetDomainToApplication()
    {
      return DomainToApplication.Instance;
    }

    public IInfrastructureToApplication GetInfrastructureToApplication()
    {
      return InfrastructureToApplication.Instance;
    }
  }
}
