using Microsoft.EntityFrameworkCore;
using QueryBank.Application.Repositories;
using QueryBank.EventConsumer.Services;
using QueryBank.EventConsumer.Subscribers;
using QueryBank.Infrastructure.Persistence;
using QueryBank.Infrastructure.Persistence.Models;
using QueryBank.Infrastructure.Persistence.Repositories;
using QueryBank.Infrastructure.Services;
using Shared.Infrastructure.Events;
using StackExchange.Redis;

var builder = Host.CreateApplicationBuilder(args);

// == Configure connection to Redis for subscribing to messages ==
var connectionString = builder.Configuration.GetConnectionString("BrokerConnection");
if (connectionString != null)
{
  builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(connectionString)
  );
}
builder.Services.AddHostedService<QueryBankSubscriber>();
// ===============================================================

// == Configure connection to the database ==
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionDataBase"));
});
// ==========================================

// == Configure repositories ==
builder.Services.AddSingleton<ISkillRepository<SkillModel>, SkillRepository>(serviceProvider =>
{
  var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
  return new SkillRepository(dbContext);
});
// ============================

// == Configure dependency injection for services ==
builder.Services.AddSingleton<SharedEventHandler>();
builder.Services.AddSingleton<ApplicationService>();
builder.Services.AddSingleton<QueryBankServiceForSubscribers>();
// =================================================

var app = builder.Build();

app.Run();
