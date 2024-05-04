using Assessments.Application.AntiCorruption.Interfaces;
using Assessments.Infrastructure.AntiCorruption.Interfaces;

namespace Assessments.Infrastructure.AntiCorruption
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
