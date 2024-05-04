using QueryBank.Application.AntiCorruption.Interfaces;

namespace QueryBank.Infrastructure.AntiCorruption.Interfaces
{
  public interface IAntiCorruptionLayer
  {
    public IApplicationToDomain GetApplicationToDomain();
    public IApplicationToInfrastructure GetApplicationToInfrastructure();
    public IDomainToApplication GetDomainToApplication();
    public IInfrastructureToApplication GetInfrastructureToApplication();
  }
}
