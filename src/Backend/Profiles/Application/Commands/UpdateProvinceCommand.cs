using Shared.Application.Interfaces;

namespace Profiles.Application.Commands
{
  public sealed class UpdateProvinceCommand : ICommand
  {
    public required string ProvinceId { get; init; }
    public string? CountryId { get; init; }
    public string? Name { get; init; }
    public bool? Disable { get; init; }
  }
}
