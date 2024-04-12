using Shared.Domain.Aggregate.Interfaces;

namespace Shared.Application.Base;

public abstract class BaseUseCase<TCommand, TResponse, TAggregate>
    where TAggregate : IAggregate
{
    protected readonly TAggregate AggregateRoot;

    protected BaseUseCase(TAggregate aggregateRoot)
    {
        AggregateRoot = aggregateRoot;
    }

    public abstract Task<TResponse> Handle(TCommand request);

    protected void EmitEvent(string channel, string data)
    {
        AggregateRoot.EmitEvent(channel, data);
    }
}
