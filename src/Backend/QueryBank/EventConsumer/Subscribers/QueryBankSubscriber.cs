using System.Text.Json;
using QueryBank.EventConsumer.Services;
using QueryBank.EventConsumer.Services.Dto.Requests;
using StackExchange.Redis;

namespace QueryBank.EventConsumer.Subscribers
{
  public class QueryBankSubscriber : BackgroundService
  {
    protected readonly IConnectionMultiplexer ConnectionMultiplexer;
    protected readonly ISubscriber Subscriber;
    protected readonly IServiceProvider ServiceProvider;

    public QueryBankSubscriber(
      IConnectionMultiplexer connectionMultiplexer,
      IServiceProvider serviceProvider
    )
    {
      ConnectionMultiplexer = connectionMultiplexer;
      Subscriber = ConnectionMultiplexer.GetSubscriber();
      ServiceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      await Subscriber.SubscribeAsync(
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

          using (var scope = ServiceProvider.CreateScope())
          {
            var queryBankServiceForSubscribers =
              scope.ServiceProvider.GetRequiredService<QueryBankServiceForSubscribers>();
            await queryBankServiceForSubscribers.RegisterSkillAsync(data);
          }
        }
      );

      await Subscriber.SubscribeAsync(
        new RedisChannel("Profiles.SkillUpdated", RedisChannel.PatternMode.Literal),
        async (channel, message) =>
        {
          var data = JsonSerializer.Deserialize<UpdateSkillQueryBankRequest>(
            message.ToString() ?? string.Empty
          );
          if (data == null)
          {
            return;
          }

          using (var scope = ServiceProvider.CreateScope())
          {
            var queryBankServiceForSubscribers =
              scope.ServiceProvider.GetRequiredService<QueryBankServiceForSubscribers>();
            await queryBankServiceForSubscribers.UpdateSkillRoleAsync(data);
          }
        }
      );

      await Subscriber.SubscribeAsync(
        new RedisChannel("Profiles.SkillDeleted", RedisChannel.PatternMode.Literal),
        async (channel, message) =>
        {
          var data = JsonSerializer.Deserialize<DeleteSkillQueryBankRequest>(
            message.ToString() ?? string.Empty
          );
          if (data == null)
          {
            return;
          }

          using (var scope = ServiceProvider.CreateScope())
          {
            var queryBankServiceForSubscribers =
              scope.ServiceProvider.GetRequiredService<QueryBankServiceForSubscribers>();
            await queryBankServiceForSubscribers.DeleteSkillAsync(data);
          }
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
