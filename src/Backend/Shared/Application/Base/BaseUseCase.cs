using Shared.Domain.Aggregate.Interfaces;

namespace Shared.Application.Base
{
  public abstract class BaseUseCase<TCommand, TResponse, TAggregateRoot>
    where TAggregateRoot : IAggregateRoot
  {
    protected readonly TAggregateRoot AggregateRoot;

    protected BaseUseCase(TAggregateRoot aggregateRoot)
    {
      AggregateRoot = aggregateRoot;
    }

    public abstract Task<TResponse> Handle(TCommand request);

    protected void EmitEvent(string channel, string data)
    {
      AggregateRoot.EmitEvent(channel, data);
    }
  }
}
