using AccessControl.Application.AntiCorruption.Interfaces;

namespace AccessControl.Infrastructure.AntiCorruption.Interfaces
{
  public interface IAntiCorruptionLayer
  {
    public IApplicationToDomain GetApplicationToDomain();
    public IApplicationToInfrastructure GetApplicationToInfrastructure();
    public IDomainToApplication GetDomainToApplication();
    public IInfrastructureToApplication GetInfrastructureToApplication();
  }
}
