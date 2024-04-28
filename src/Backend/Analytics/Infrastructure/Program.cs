using Microsoft.EntityFrameworkCore;
using Analytics.Application.Repositories;
using Analytics.Infrastructure.Messaging.Events;
using Analytics.Infrastructure.Persistence.Models;
using Analytics.Infrastructure.Persistence.Repositories;
using Analytics.Infrastructure.Services;
using ProtoBuf.Grpc.Server;
using Shared.Infrastructure.Interceptors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure connection to the database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ILevelRepository<Level>, LevelRepository>(serviceProvider =>
{
    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
    return new LevelRepository(dbContext);
});

builder.Services.AddScoped<RegisterLevelEvent>();

// Add services to the container.
builder.Services.AddSingleton<ErrorHandlingInterceptor>();

builder.Services.AddCodeFirstGrpc(options =>
{
    options.Interceptors.Add<ErrorHandlingInterceptor>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<AnalyticsService>();
app.MapGet(
    "/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. "
        + "To learn how to create a client, visit: "
        + "https://go.microsoft.com/fwlink/?linkid=2086909"
);

app.Run();
