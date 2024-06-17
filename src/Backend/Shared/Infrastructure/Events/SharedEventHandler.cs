using Shared.Infrastructure.Events.Base;
using StackExchange.Redis;

namespace Shared.Infrastructure.Events
{
  public class SharedEventHandler(IConnectionMultiplexer connection) : BaseEvent(connection) { }
}
