using ApiGateway.Infrastructure.Services;
using Shared.Application.Interfaces;
using Shared.Infrastructure.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// == Configure the app configuration ==
builder
  .Configuration.AddJsonFile(
    "appsettings.ApiGateway.Infrastructure.json",
    optional: false,
    reloadOnChange: true
  )
  .AddJsonFile(
    $"appsettings.ApiGateway.Infrastructure.{builder.Environment.EnvironmentName}.json",
    optional: true,
    reloadOnChange: true
  )
  .AddEnvironmentVariables();

// =====================================

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

// == Load url for gRPC services ==
var grpcAccessControlUrl = builder.Configuration.GetConnectionString("gRPCAccessControl") ?? "";
var grpcAnalyticsUrl = builder.Configuration.GetConnectionString("gRPCAnalytics") ?? "";
var grpcAssessmentUrl = builder.Configuration.GetConnectionString("gRPCAssessment") ?? "";
var grpcProfilesUrl = builder.Configuration.GetConnectionString("gRPCProfiles") ?? "";
var grpcQueryBank = builder.Configuration.GetConnectionString("gRPCQueryBank") ?? "";

// ================================

if (builder.Environment.IsDevelopment())
{
  AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
  var httpClientHandler = new HttpClientHandler
  {
    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
  };

  builder.Services.AddSingleton(provider => new AccessControlService(
    grpcAccessControlUrl,
    httpClientHandler
  ));
  builder.Services.AddSingleton(provider => new ProfilesService(
    grpcProfilesUrl,
    httpClientHandler
  ));
  builder.Services.AddSingleton(provider => new AnalyticsService(
    grpcAnalyticsUrl,
    httpClientHandler
  ));
  builder.Services.AddSingleton<ICacheService, CacheService>();
}
else
{
  var httpClientHandler = new HttpClientHandler
  {
    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
    {
      return cert != null && cert.Subject.Contains("E=julian.lasso@sofka.com.co");
    }
  };

  builder.Services.AddSingleton(provider => new AccessControlService(
    grpcAccessControlUrl,
    httpClientHandler
  ));
  builder.Services.AddSingleton(provider => new ProfilesService(
    grpcProfilesUrl,
    httpClientHandler
  ));
  builder.Services.AddSingleton(provider => new AnalyticsService(
    grpcAnalyticsUrl,
    httpClientHandler
  ));
  builder.Services.AddSingleton<ICacheService, CacheService>();
}

// == Define CORS policy ==
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

// ========================

// == Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle ==
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ===========================================================================================

var app = builder.Build();

// == Enable CORS ==
app.UseCors("AllowAll");

// =================

// == Enable Swagger only in development environment ==
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// ====================================================

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();
