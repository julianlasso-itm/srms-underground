using ApiGateway.Infrastructure.Services;
using Shared.Infrastructure.Cache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization(
  options =>
  {
    options.AddPolicy(
      "Admin",
      policy =>
      {
        policy.RequireRole("admin");
      }
    );
  }
);
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
  builder.Services.AddSingleton<ICache, CacheService>();
}
else
{
  builder.Services.AddSingleton<AccessControlService>();
  builder.Services.AddSingleton<ProfilesService>();
  builder.Services.AddSingleton<AnalyticsService>();
  builder.Services.AddSingleton<ICache, CacheService>();
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
