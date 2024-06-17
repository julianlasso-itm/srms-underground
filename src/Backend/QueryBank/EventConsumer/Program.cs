using Microsoft.EntityFrameworkCore;
using QueryBank.Application.Repositories;
using QueryBank.EventConsumer.Services;
using QueryBank.EventConsumer.Subscribers;
using QueryBank.Infrastructure.AntiCorruption;
using QueryBank.Infrastructure.Persistence;
using QueryBank.Infrastructure.Persistence.Models;
using QueryBank.Infrastructure.Persistence.Repositories;
using QueryBank.Infrastructure.Services;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Services;
using StackExchange.Redis;

var builder = Host.CreateApplicationBuilder(args);

// == Configure the app configuration ==
builder
  .Configuration.AddJsonFile(
    "appsettings.QueryBank.EventConsumer.json",
    optional: false,
    reloadOnChange: true
  )
  .AddJsonFile(
    $"appsettings.QueryBank.EventConsumer.{builder.Environment.EnvironmentName}.json",
    optional: true,
    reloadOnChange: true
  )
  .AddEnvironmentVariables();

// =====================================

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
builder.Services.AddScoped<ISkillRepository<SkillModel>, SkillRepository>();

// ============================

// == Configure dependency injection for services ==
builder.Services.AddSingleton<SharedEventHandler>();
builder.Services.AddScoped<ApplicationService>();
builder.Services.AddScoped<QueryBankServiceForSubscribers>();
builder.Services.AddScoped<AntiCorruptionLayerService<AntiCorruptionLayer>>();

// =================================================

var host = builder.Build();

host.Run();
