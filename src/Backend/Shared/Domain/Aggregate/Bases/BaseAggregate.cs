using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Events.Interfaces;

namespace Shared.Domain.Aggregate.Bases
{
  public abstract class BaseAggregateRoot(IEvent eventInterface) : IAggregateRoot
  {
    protected readonly IEvent EventInterface = eventInterface;

    public void EmitEvent(string channel, string data)
    {
      EventInterface.Emit(channel, data);
    }
  }
}
