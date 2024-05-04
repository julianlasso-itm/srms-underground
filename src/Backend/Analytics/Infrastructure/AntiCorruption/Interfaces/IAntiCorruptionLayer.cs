using Analytics.Application.AntiCorruption.Interfaces;

namespace Analytics.Infrastructure.AntiCorruption.Interfaces
{
  public interface IAntiCorruptionLayer
  {
    public IApplicationToDomain GetApplicationToDomain();
    public IApplicationToInfrastructure GetApplicationToInfrastructure();
    public IDomainToApplication GetDomainToApplication();
    public IInfrastructureToApplication GetInfrastructureToApplication();
  }
}
