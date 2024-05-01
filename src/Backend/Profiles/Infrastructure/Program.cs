using Microsoft.EntityFrameworkCore;
using Profiles.Application.Repositories;
using Profiles.Infrastructure.Persistence;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Persistence.Repositories;
using Profiles.Infrastructure.Services;
using ProtoBuf.Grpc.Server;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Interceptors;

var builder = WebApplication.CreateBuilder(args);

// == Configure connection to the database ==
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionDataBase"));
});
// ==========================================

// == Configure repositories ==
builder.Services.AddScoped<ICountryRepository<CountryModel>, CountryRepository>();
builder.Services.AddScoped<IProvinceRepository<ProvinceModel>, ProvinceRepository>();
builder.Services.AddScoped<ICityRepository<CityModel>, CityRepository>();
builder.Services.AddScoped<IRoleRepository<RoleModel>, RoleRepository>();
builder.Services.AddScoped<ISkillRepository<SkillModel>, SkillRepository>();
builder.Services.AddScoped<IProfessionalRepository<ProfessionalModel>, ProfessionalRepository>();
// ============================

// == Configure dependency injection for services ==
builder.Services.AddScoped<SharedEventHandler>();
builder.Services.AddScoped<ApplicationService>();
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
