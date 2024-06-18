using Shared.Common.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace Shared.Application.Base
{
  public abstract class BaseUseCase<TCommand, TAggregateRoot, TAclInputMapper, TAclOutputMapper>(
    TAggregateRoot aggregateRoot,
    TAclInputMapper aclInputMapper,
    TAclOutputMapper aclOutputMapper
  )
    where TAggregateRoot : IAggregateRoot
  {
    protected readonly TAggregateRoot AggregateRoot = aggregateRoot;
    protected readonly TAclInputMapper AclInputMapper = aclInputMapper;
    protected readonly TAclOutputMapper AclOutputMapper = aclOutputMapper;

    public abstract Task<Result> Handle(TCommand request);

    protected void EmitEvent(string channel, string data)
    {
      AggregateRoot.EmitEvent(channel, data);
    }
  }
}
