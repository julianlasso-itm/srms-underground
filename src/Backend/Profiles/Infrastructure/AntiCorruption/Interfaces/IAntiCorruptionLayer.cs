using Profiles.Application.AntiCorruption.Interfaces;

namespace Profiles.Infrastructure.AntiCorruption.Interfaces
{
  public interface IAntiCorruptionLayer
  {
    public IApplicationToDomain GetApplicationToDomain();
    public IApplicationToInfrastructure GetApplicationToInfrastructure();
    public IDomainToApplication GetDomainToApplication();
    public IInfrastructureToApplication GetInfrastructureToApplication();
  }
}
