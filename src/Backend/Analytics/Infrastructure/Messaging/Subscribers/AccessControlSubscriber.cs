using StackExchange.Redis;

namespace Analytics.Infrastructure.Messaging.Subscribers;

public class AccessControlSubscriber : BackgroundService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly ISubscriber _subscriber;

    public AccessControlSubscriber(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
        _subscriber = _connectionMultiplexer.GetSubscriber();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _subscriber.SubscribeAsync(
            "AccessControl.RoleRegistered",
            (channel, message) =>
            {
                Console.WriteLine($"Mensaje recibido (RoleRegistered): {message}");
            }
        );

        await _subscriber.SubscribeAsync(
            "AccessControl.RoleUpdated",
            (channel, message) =>
            {
                Console.WriteLine($"Mensaje recibido (RoleUpdated): {message}");
            }
        );

        // Mantener el servicio en ejecución
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
