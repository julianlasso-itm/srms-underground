using ApiGateway.Infrastructure.Services;
using Shared.Application.Interfaces;
using Shared.Infrastructure.ProtocolBuffers.AccessControl;
using Shared.Infrastructure.ProtocolBuffers.Analytics;
using Shared.Infrastructure.ProtocolBuffers.Profiles;
using Shared.Infrastructure.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// == Configure connection to Redis ==
var multiplexer = ConnectionMultiplexer.Connect(
  builder.Configuration.GetConnectionString("RedisConnection")!
);
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
// ===================================

// Add services to the container.
builder.Services.AddAuthorization(options =>
{
  options.AddPolicy(
    "Admin",
    policy =>
    {
      policy.RequireRole("admin");
    }
  );
});
builder.Services.AddControllers();

// Configure services conditionally for development environment
if (builder.Environment.IsDevelopment())
{
  AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
  var httpClientHandler = new HttpClientHandler
  {
    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
  };

  builder.Services.AddSingleton(provider => new AccessControlService(httpClientHandler));
  builder.Services.AddSingleton(provider => new ProfilesService(httpClientHandler));
  builder.Services.AddSingleton(provider => new AnalyticsService(httpClientHandler));
  builder.Services.AddSingleton<ICacheService, CacheService>();
}
else
{
  builder.Services.AddSingleton<IAccessControlServices, AccessControlService>();
  builder.Services.AddSingleton<IProfilesServices, ProfilesService>();
  builder.Services.AddSingleton<IAnalyticsServices, AnalyticsService>();
  builder.Services.AddSingleton<ICacheService, CacheService>();
}

// Define CORS policy
builder.Services.AddCors(options =>
{
  options.AddPolicy(
    "AllowAll",
    builder =>
    {
      builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }
  );
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable CORS
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
