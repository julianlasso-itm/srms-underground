using System.Text.Json;
using QueryBank.EventConsumer.Services;
using QueryBank.EventConsumer.Services.Dto.Requests;
using StackExchange.Redis;

namespace QueryBank.EventConsumer.Subscribers
{
  public class QueryBankSubscriber : BackgroundService
  {
    protected readonly IConnectionMultiplexer _connectionMultiplexer;
    protected readonly ISubscriber _subscriber;
    protected readonly QueryBankServiceForSubscribers _queryBankServiceForSubscribers;

    public QueryBankSubscriber(
      IConnectionMultiplexer connectionMultiplexer,
      QueryBankServiceForSubscribers queryBankServiceForSubscribers
    )
    {
      _connectionMultiplexer = connectionMultiplexer;
      _subscriber = _connectionMultiplexer.GetSubscriber();
      _queryBankServiceForSubscribers = queryBankServiceForSubscribers;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      await _subscriber.SubscribeAsync(
        new RedisChannel("Profiles.SkillRegistered", RedisChannel.PatternMode.Literal),
        async (channel, message) =>
        {
          var data = JsonSerializer.Deserialize<RegisterSkillQueryBankRequest>(
            message.ToString() ?? string.Empty
          );
          if (data == null)
          {
            return;
          }
          await _queryBankServiceForSubscribers.RegisterSkillAsync(data);
        }
      );

      // Keep the service running
      while (!stoppingToken.IsCancellationRequested)
      {
        await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
      }
    }
  }
}
