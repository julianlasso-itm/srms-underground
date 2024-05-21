using Shared.Infrastructure.Events.Base;
using StackExchange.Redis;

namespace Shared.Infrastructure.Events
{
  public class SharedEventHandler : BaseEvent
  {
    public SharedEventHandler(IConnectionMultiplexer connection)
      : base(connection) { }
  }
}
