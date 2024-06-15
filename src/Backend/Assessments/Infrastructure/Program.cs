var builder = WebApplication.CreateBuilder(args);

// == Configure the app configuration ==
builder
  .Configuration.AddJsonFile(
    "appsettings.Assessments.Infrastructure.json",
    optional: false,
    reloadOnChange: true
  )
  .AddJsonFile(
    $"appsettings.Assessments.Infrastructure.{builder.Environment.EnvironmentName}.json",
    optional: true,
    reloadOnChange: true
  )
  .AddEnvironmentVariables();
// =====================================

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

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
