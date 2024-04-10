using Shared.Domain.Events.Interfaces;
using StackExchange.Redis;

namespace Shared.Infrastructure.Events.Base;

public abstract class BaseEvent : IEvent
{
    private string Uri { get; }
    private ISubscriber Subscriber { get; }

    protected BaseEvent(string uri)
    {
        Uri = uri;
        Subscriber = CreateSubscriber();
    }

    public void Emit(string channel, string data)
    {
        var myChannel = new RedisChannel(channel, RedisChannel.PatternMode.Literal);
        _ = Subscriber.Publish(myChannel, data);
    }

    private ISubscriber CreateSubscriber()
    {
        var connection = ConnectionMultiplexer.Connect(Uri);
        return connection.GetSubscriber();
    }
}
