using Shared.Domain.Events.Interfaces;

namespace Shared.Domain.Aggregate.Base;

public abstract class BaseAggregate
{
    protected readonly IEvent EventInterface;

    public BaseAggregate(IEvent eventInterface)
    {
        EventInterface = eventInterface;
    }

    protected void EmitEvent(string channel, string data)
    {
        EventInterface.Emit(channel, data);
    }
}
