namespace Shared.Application.Base
{
  public abstract class BaseApplication<TAggregateRoot, TApplicationToDomain, TDomainToApplication>
  {
    public required TAggregateRoot AggregateRoot { get; init; }
    protected readonly TApplicationToDomain ApplicationToDomain;
    protected readonly TDomainToApplication DomainToApplication;

    public BaseApplication(
      TApplicationToDomain applicationToDomain,
      TDomainToApplication domainToApplication
    )
    {
      ApplicationToDomain = applicationToDomain;
      DomainToApplication = domainToApplication;
    }
  }
}
