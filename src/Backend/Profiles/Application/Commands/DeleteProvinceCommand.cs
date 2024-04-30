using Shared.Application.Interfaces;

namespace Profiles.Application.Commands
{
  public sealed class DeleteProvinceCommand : ICommand
  {
    public required string ProvinceId { get; init; }
  }
}
