using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// == Configure connection to the database ==
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// ==========================================

// Add services to the container.
// builder.Services.AddGrpc();

var app = builder.Build();

// Ensure the database is created or migrated before starting the application
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
// app.MapGrpcService<GreeterService>();
app.MapGet(
    "/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. "
        + "To learn how to create a client, visit: "
        + "https://go.microsoft.com/fwlink/?linkid=2086909"
);

app.Run();
