using StackExchange.Redis;

namespace Analytics.Infrastructure.Messaging.Subscribers;

public class AnalyticsSubscriber : BackgroundService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly ISubscriber _subscriber;

    public AnalyticsSubscriber(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
        _subscriber = _connectionMultiplexer.GetSubscriber();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _subscriber.SubscribeAsync(
            new RedisChannel("AccessControl.RoleRegistered", RedisChannel.PatternMode.Literal),
            (channel, message) =>
            {
                Console.WriteLine($"Message received (RoleRegistered): {message}");
            }
        );

        await _subscriber.SubscribeAsync(
            new RedisChannel("AccessControl.RoleUpdated", RedisChannel.PatternMode.Literal),
            (channel, message) =>
            {
                Console.WriteLine($"Message received (RoleUpdated): {message}");
            }
        );

        // Keep the service running
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
