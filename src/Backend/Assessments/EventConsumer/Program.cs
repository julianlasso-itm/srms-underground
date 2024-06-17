var builder = Host.CreateApplicationBuilder(args);

// == Configure the app configuration ==
builder
  .Configuration.AddJsonFile(
    "appsettings.Assessments.EventConsumer.json",
    optional: false,
    reloadOnChange: true
  )
  .AddJsonFile(
    $"appsettings.Assessments.EventConsumer.{builder.Environment.EnvironmentName}.json",
    optional: true,
    reloadOnChange: true
  )
  .AddEnvironmentVariables();

// =====================================

// builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
