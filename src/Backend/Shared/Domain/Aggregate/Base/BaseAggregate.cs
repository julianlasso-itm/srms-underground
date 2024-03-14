using Shared.Domain.Events.Interfaces;

namespace Shared.Domain.Aggregate.Base;

public abstract class BaseAggregate
{
    protected readonly IEvent _eventInterface;

    public BaseAggregate(IEvent eventInterface)
    {
        _eventInterface = eventInterface;
    }

    protected void EmitEvent<TypeObject>(string eventName, TypeObject data)
    {
        _eventInterface.Emit<TypeObject>(eventName, data);
    }
}
