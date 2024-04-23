using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Events.Interfaces;

namespace Shared.Domain.Aggregate.Base;

public abstract class BaseAggregateRoot : IAggregateRoot
{
    protected readonly IEvent EventInterface;

    public BaseAggregateRoot(IEvent eventInterface)
    {
        EventInterface = eventInterface;
    }

    public void EmitEvent(string channel, string data)
    {
        EventInterface.Emit(channel, data);
    }
}
