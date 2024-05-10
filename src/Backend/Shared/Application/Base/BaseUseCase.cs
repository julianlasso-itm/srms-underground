using Shared.Domain.Aggregate.Interfaces;

namespace Shared.Application.Base
{
  public abstract class BaseUseCase<
    TCommand,
    TResponse,
    TAggregateRoot,
    TAclInputMapper,
    TAclOutputMapper
  >
    where TAggregateRoot : IAggregateRoot
  {
    protected readonly TAggregateRoot AggregateRoot;
    protected readonly TAclInputMapper AclInputMapper;
    protected readonly TAclOutputMapper AclOutputMapper;

    protected BaseUseCase(
      TAggregateRoot aggregateRoot,
      TAclInputMapper aclInputMapper,
      TAclOutputMapper aclOutputMapper
    )
    {
      AggregateRoot = aggregateRoot;
      AclInputMapper = aclInputMapper;
      AclOutputMapper = aclOutputMapper;
    }

    public abstract Task<TResponse> Handle(TCommand request);

    protected void EmitEvent(string channel, string data)
    {
      AggregateRoot.EmitEvent(channel, data);
    }
  }
}
