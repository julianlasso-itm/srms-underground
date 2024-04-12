using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Events.Interfaces;

namespace Shared.Domain.Aggregate.Base;

public abstract class BaseAggregate : IAggregate
{
    protected readonly IEvent EventInterface;

    public BaseAggregate(IEvent eventInterface)
    {
        EventInterface = eventInterface;
    }

    public void EmitEvent(string channel, string data)
    {
        EventInterface.Emit(channel, data);
    }
}
