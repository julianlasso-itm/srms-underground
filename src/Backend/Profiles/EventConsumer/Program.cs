var builder = Host.CreateApplicationBuilder(args);

// == Configure the app configuration ==
builder
  .Configuration.AddJsonFile(
    "appsettings.Profiles.EventConsumer.json",
    optional: false,
    reloadOnChange: true
  )
  .AddJsonFile(
    $"appsettings.Profiles.EventConsumer.{builder.Environment.EnvironmentName}.json",
    optional: true,
    reloadOnChange: true
  )
  .AddEnvironmentVariables();

// =====================================

// builder.Services.AddHostedService<Worker>();

var host = builder.Build();

host.Run();
