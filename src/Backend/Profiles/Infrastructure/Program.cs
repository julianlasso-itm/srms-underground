using Microsoft.EntityFrameworkCore;
using Profiles.Application.Repositories;
using Profiles.Infrastructure.Messaging.Events;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Persistence.Repositories;
using Profiles.Infrastructure.Services;
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

builder.Services.AddScoped<ISkillRepository<Skill>, SkillRepository>(serviceProvider =>
{
    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
    return new SkillRepository(dbContext);
});
builder.Services.AddScoped<IProfessionalRepository<Professional>, ProfessionalRepository>(serviceProvider =>
{
    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
    return new ProfessionalRepository(dbContext);
});

builder.Services.AddScoped<RegisterSkillEvent>();
builder.Services.AddScoped<RegisterProfessionalEvent>();
builder.Services.AddScoped<ApplicationService>();

// Add services to the container.
builder.Services.AddSingleton<ErrorHandlingInterceptor>();

builder.Services.AddCodeFirstGrpc(options =>
{
    options.Interceptors.Add<ErrorHandlingInterceptor>();
});



var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ProfilesService>();
app.MapGet(
    "/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. "
        + "To learn how to create a client, visit: "
        + "https://go.microsoft.com/fwlink/?linkid=2086909"
);

app.Run();
