using Shared.Application.Interfaces;

namespace AccessControl.Infrastructure.Services
{
  public class EnvironmentService : IEnvironment
  {
    private readonly IConfiguration _configuration;
    private readonly Dictionary<string, string> _environmentVariables =
      new Dictionary<string, string>();

    public EnvironmentService(IConfiguration configuration)
    {
      _configuration = configuration;
      _environmentVariables.Add(
        "PRIVATE_KEY_PATH",
        _configuration["Jwt:PrivateKey"] ?? string.Empty
      );
      _environmentVariables.Add(
        "PUBLIC_KEY_PATH",
        _configuration["Jwt:PrivateKey"] ?? string.Empty
      );
    }

    public string GetVariable(string key)
    {
      return _environmentVariables[key];
    }
  }
}
