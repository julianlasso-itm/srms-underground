using AccessControl.Infrastructure.AntiCorruption.Interfaces;

namespace AccessControl.Infrastructure.AntiCorruption
{
  public class AntiCorruptionLayer : IAntiCorruptionLayer
  {
    ApplicationToDomain IAntiCorruptionLayer.ApplicationToDomain()
    {
      return ApplicationToDomain.Instance;
    }

    ApplicationToInfrastructure IAntiCorruptionLayer.ApplicationToInfrastructure()
    {
      return ApplicationToInfrastructure.Instance;
    }

    DomainToApplication IAntiCorruptionLayer.DomainToApplication()
    {
      return DomainToApplication.Instance;
    }

    InfrastructureToApplication IAntiCorruptionLayer.InfrastructureToApplication()
    {
      return InfrastructureToApplication.Instance;
    }
  }
}
