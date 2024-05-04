namespace AccessControl.Infrastructure.AntiCorruption.Interfaces
{
  public interface IAntiCorruptionLayer
  {
    public ApplicationToDomain ApplicationToDomain();
    public ApplicationToInfrastructure ApplicationToInfrastructure();
    public DomainToApplication DomainToApplication();
    public InfrastructureToApplication InfrastructureToApplication();
  }
}
