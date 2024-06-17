var builder = Host.CreateApplicationBuilder(args);

// == Configure the app configuration ==
builder
  .Configuration.AddJsonFile(
    "appsettings.AccessControl.EventConsumer.json",
    optional: false,
    reloadOnChange: true
  )
  .AddJsonFile(
    $"appsettings.AccessControl.EventConsumer.{builder.Environment.EnvironmentName}.json",
    optional: true,
    reloadOnChange: true
  )
  .AddEnvironmentVariables();

// =====================================

// builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
