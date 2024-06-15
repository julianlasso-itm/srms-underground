using Microsoft.EntityFrameworkCore;
using Profiles.Application.Repositories;
using Profiles.Infrastructure.AntiCorruption;
using Profiles.Infrastructure.AntiCorruption.Interfaces;
using Profiles.Infrastructure.Persistence;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Persistence.Repositories;
using Profiles.Infrastructure.Services;
using ProtoBuf.Grpc.Server;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Interceptors;
using Shared.Infrastructure.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// == Configure connection to the database ==
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionDataBase"));
}, ServiceLifetime.Scoped);
// ==========================================

// == Configure connection to Redis ==
var multiplexer = ConnectionMultiplexer.Connect(
  builder.Configuration.GetConnectionString("RedisConnection")!
);
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
// ===================================

// == Configure repositories ==
builder.Services.AddScoped<ICountryRepository<CountryModel>, CountryRepository>();
builder.Services.AddScoped<IProvinceRepository<ProvinceModel>, ProvinceRepository>();
builder.Services.AddScoped<ICityRepository<CityModel>, CityRepository>();
builder.Services.AddScoped<IRoleRepository<RoleModel>, RoleRepository>();
builder.Services.AddScoped<ISkillRepository<SkillModel>, SkillRepository>();
builder.Services.AddScoped<ISubSkillRepository<SubSkillModel>, SubSkillRepository>();
builder.Services.AddScoped<ISquadRepository<SquadModel>, SquadRepository>();
builder.Services.AddScoped<IProfessionalRepository<ProfessionalModel>, ProfessionalRepository>();
builder.Services.AddScoped<IAssessmentRepository<AssessmentModel>, AssessmentRepository>();
builder.Services.AddScoped<ILevelRepository<LevelModel>, LevelRepository>();
builder.Services.AddScoped<IPodiumRepository<PodiumModel>, PodiumRepository>();
// ============================

// == Configure dependency injection for services ==
builder.Services.AddScoped<SharedEventHandler>();
builder.Services.AddScoped<ApplicationService>();
builder.Services.AddScoped<IAntiCorruptionLayer, AntiCorruptionLayer>();
builder.Services.AddScoped<AntiCorruptionLayerService<AntiCorruptionLayer>>();
// =================================================

// == Configure interceptors for gRPC services ==
builder.Services.AddSingleton<ErrorHandlingInterceptor>();
// ==============================================

// == Configure gRPC services ==
builder.Services.AddCodeFirstGrpc(options =>
{
  options.Interceptors.Add<ErrorHandlingInterceptor>();
});
// ========================================

var app = builder.Build();

// == Ensure the database is created or migrated before starting the application ==
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  var context = services.GetRequiredService<ApplicationDbContext>();
  context.Database.Migrate();
}
// ================================================================================

// == Configure gRPC services ==
app.MapGrpcService<ProfilesService>();
// =============================

app.MapGet(
  "/",
  () =>
    "Communication with gRPC endpoints must be made through a gRPC client. "
    + "To learn how to create a client, visit: "
    + "https://go.microsoft.com/fwlink/?linkid=2086909"
);

app.Run();
