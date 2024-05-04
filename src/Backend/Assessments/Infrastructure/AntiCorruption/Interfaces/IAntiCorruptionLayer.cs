using Assessments.Application.AntiCorruption.Interfaces;

namespace Assessments.Infrastructure.AntiCorruption.Interfaces
{
  public interface IAntiCorruptionLayer
  {
    public IApplicationToDomain GetApplicationToDomain();
    public IApplicationToInfrastructure GetApplicationToInfrastructure();
    public IDomainToApplication GetDomainToApplication();
    public IInfrastructureToApplication GetInfrastructureToApplication();
  }
}
