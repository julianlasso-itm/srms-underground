namespace Shared.Application.Base
{
  public abstract class BaseApplication<TAggregateRoot, TApplicationToDomain, TDomainToApplication>(
    TApplicationToDomain applicationToDomain,
    TDomainToApplication domainToApplication
  )
  {
    public required TAggregateRoot AggregateRoot { get; init; }
    protected readonly TApplicationToDomain ApplicationToDomain = applicationToDomain;
    protected readonly TDomainToApplication DomainToApplication = domainToApplication;
  }
}
