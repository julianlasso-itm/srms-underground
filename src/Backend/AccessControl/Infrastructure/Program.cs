using AccessControl.Application.Repositories;
using AccessControl.Infrastructure.Persistence;
using AccessControl.Infrastructure.Persistence.Models;
using AccessControl.Infrastructure.Persistence.Repositories;
using AccessControl.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc.Server;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Interceptors;

var builder = WebApplication.CreateBuilder(args);

// Configure connection to the database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IRoleRepository<RoleModel>, RoleRepository>(serviceProvider =>
{
    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
    return new RoleRepository(dbContext);
});
builder.Services.AddScoped<SharedEventHandler>();
builder.Services.AddScoped<ApplicationService>();

// Add services to the container.
builder.Services.AddSingleton<ErrorHandlingInterceptor>();

builder.Services.AddCodeFirstGrpc(options =>
{
    options.Interceptors.Add<ErrorHandlingInterceptor>();
});

var app = builder.Build();

// Ensure the database is created or migrated before starting the application
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.MapGrpcService<AccessControlService>();
app.MapGet(
    "/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. "
        + "To learn how to create a client, "
        + "visit: https://go.microsoft.com/fwlink/?linkid=2086909"
);

app.Run();
