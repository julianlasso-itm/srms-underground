using Analytics.Application.Repositories;
using Analytics.Infrastructure.AntiCorruption;
using Analytics.Infrastructure.AntiCorruption.Interfaces;
using Analytics.Infrastructure.Persistence;
using Analytics.Infrastructure.Persistence.Models;
using Analytics.Infrastructure.Persistence.Repositories;
using Analytics.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc.Server;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Interceptors;
using Shared.Infrastructure.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// == Configure the app configuration ==
builder
  .Configuration.AddJsonFile(
    "appsettings.Analytics.Infrastructure.json",
    optional: false,
    reloadOnChange: true
  )
  .AddJsonFile(
    $"appsettings.Analytics.Infrastructure.{builder.Environment.EnvironmentName}.json",
    optional: true,
    reloadOnChange: true
  )
  .AddEnvironmentVariables();

// =====================================

// == Configure connection to the database ==
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionDataBase"));
});

// ==========================================

// == Configure connection to Redis ==
var multiplexer = ConnectionMultiplexer.Connect(
  builder.Configuration.GetConnectionString("RedisConnection")!
);
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);

// ===================================

// == Configure repositories ==
builder.Services.AddScoped<ILevelRepository<LevelModel>, LevelRepository>();

// ============================

// == Configure dependency injection for services ==
builder.Services.AddScoped<SharedEventHandler>();
builder.Services.AddScoped<ApplicationService>();
builder.Services.AddScoped<IAntiCorruptionLayer, AntiCorruptionLayer>();
builder.Services.AddScoped<AntiCorruptionLayerService<AntiCorruptionLayer>>();

// =================================================

// == Configure interceptors for gRPC services ==
builder.Services.AddSingleton<ErrorHandlingInterceptor>();

// ==============================================

// == Configure gRPC services ==
builder.Services.AddCodeFirstGrpc(options =>
{
  options.Interceptors.Add<ErrorHandlingInterceptor>();
});

// ========================================

var app = builder.Build();

// == Ensure the database is created or migrated before starting the application ==
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  var context = services.GetRequiredService<ApplicationDbContext>();
  context.Database.Migrate();
}

// ================================================================================

// == Configure gRPC services ==
app.MapGrpcService<AnalyticsService>();

// =============================

app.MapGet(
  "/",
  () =>
    "Communication with gRPC endpoints must be made through a gRPC client. "
    + "To learn how to create a client, "
    + "visit: https://go.microsoft.com/fwlink/?linkid=2086909"
);

app.Run();
