using Shared.Application.Interfaces;

namespace Profiles.Application.Commands
{
  public sealed class RegisterProvinceCommand : ICommand
  {
    public string Name { get; init; }
    public string CountryId { get; init; }
  }
}
