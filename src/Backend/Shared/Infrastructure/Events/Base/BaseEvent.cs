using Shared.Domain.Events.Interfaces;
using StackExchange.Redis;

namespace Shared.Infrastructure.Events.Base
{
  public abstract class BaseEvent(IConnectionMultiplexer connection) : IEvent
  {
    private ISubscriber Subscriber { get; } = connection.GetSubscriber();

    public void Emit(string channel, string data)
    {
      var myChannel = new RedisChannel(channel, RedisChannel.PatternMode.Literal);
      _ = Subscriber.Publish(myChannel, data);
    }
  }
}
