using StackExchange.Redis;

namespace Analytics.Infrastructure.Messaging.Subscribers;

public class AccessControlSubscriber : BackgroundService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public AccessControlSubscriber(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var subscriber = _connectionMultiplexer.GetSubscriber();
        await subscriber.SubscribeAsync(
            "AccessControl.RoleRegistered",
            (channel, message) =>
            {
                Console.WriteLine($"Mensaje recibido: {message}");
            }
        );

        // Mantener el servicio en ejecución
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
