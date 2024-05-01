using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc.Server;
using QueryBank.Application.Repositories;
using QueryBank.Infrastructure.Persistence;
using QueryBank.Infrastructure.Persistence.Models;
using QueryBank.Infrastructure.Persistence.Repositories;
using QueryBank.Infrastructure.Services;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Interceptors;

var builder = WebApplication.CreateBuilder(args);

// == Configure connection to Redis for subscribing to messages ==
// builder.Services.AddSingleton<IConnectionMultiplexer>(
//   ConnectionMultiplexer.Connect("localhost:6379")
// );
// builder.Services.AddHostedService(serviceProvider =>
// {
//   var connectionMultiplexer = serviceProvider.GetRequiredService<IConnectionMultiplexer>();
//   return new QueryBankSubscriber(
//     connectionMultiplexer,
//     serviceProvider.GetRequiredService<QueryBankServiceForSubscribers>()
//   );
// });
// builder.Services.AddHostedService<QueryBankSubscriber>();
// ===============================================================

// == Configure connection to the database ==
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// ==========================================

// == Configure repositories ==
builder.Services.AddSingleton<ISkillRepository<SkillModel>, SkillRepository>(serviceProvider =>
{
  var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
  return new SkillRepository(dbContext);
});
// builder.Services.AddScoped<ISkillRepository<SkillModel>, SkillRepository>();
// ============================

// == Configure dependency injection for services ==
builder.Services.AddSingleton<SharedEventHandler>();
builder.Services.AddSingleton<ApplicationService>();
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
// app.MapGrpcService<QueryBankService>();
// =============================

app.MapGet(
  "/",
  () =>
    "Communication with gRPC endpoints must be made through a gRPC client. "
    + "To learn how to create a client, visit: "
    + "https://go.microsoft.com/fwlink/?linkid=2086909"
);

app.Run();
