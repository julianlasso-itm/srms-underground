using Analytics.Application.Repositories;
using Analytics.Infrastructure.Messaging.Subscribers;
using Analytics.Infrastructure.Persistence;
using Analytics.Infrastructure.Persistence.Models;
using Analytics.Infrastructure.Persistence.Repositories;
using Analytics.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc.Server;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Interceptors;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// == Configure connection to Redis for subscribing to messages ==
builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect("localhost:6379")
);
builder.Services.AddHostedService<AnalyticsSubscriber>();
// ===============================================================

// == Configure connection to the database ==
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// ==========================================

// == Configure repositories ==
builder.Services.AddScoped<ILevelRepository<LevelModel>, LevelRepository>(serviceProvider =>
{
    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
    return new LevelRepository(dbContext);
});
// ============================

// == Configure dependency injection for services ==
builder.Services.AddScoped<SharedEventHandler>();
builder.Services.AddScoped<ApplicationService>();
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
