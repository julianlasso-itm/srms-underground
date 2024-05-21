using AccessControl.Application.Repositories;
using AccessControl.Infrastructure.AntiCorruption;
using AccessControl.Infrastructure.AntiCorruption.Interfaces;
using AccessControl.Infrastructure.Persistence;
using AccessControl.Infrastructure.Persistence.Models;
using AccessControl.Infrastructure.Persistence.Repositories;
using AccessControl.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc.Server;
using Shared.Application.Interfaces;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Interceptors;
using Shared.Infrastructure.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddScoped<IUserRepository<UserModel>, UserRepository>();
builder.Services.AddScoped<IRoleRepository<RoleModel>, RoleRepository>();
// builder.Services.AddScoped<IUserPerRoleRepository<UserPerRoleModel>, UserPerRoleRepository>();
// ============================

// == Configure dependency injection for services ==
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<ApplicationService>();
builder.Services.AddScoped<SharedEventHandler>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IAntiCorruptionLayer, AntiCorruptionLayer>();
builder.Services.AddScoped<AntiCorruptionLayerService<AntiCorruptionLayer>>();
builder.Services.AddScoped<IEnvironment, EnvironmentService>();
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
app.MapGrpcService<AccessControlService>();
// =============================

app.MapGet(
  "/",
  () =>
    "Communication with gRPC endpoints must be made through a gRPC client. "
    + "To learn how to create a client, "
    + "visit: https://go.microsoft.com/fwlink/?linkid=2086909"
);

app.Run();
