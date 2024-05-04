using Shared.Application.Interfaces;

namespace Profiles.Application.Commands
{
  public sealed class UpdateLevelCommand : ICommand
  {
    public required string LevelId { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public bool? Disable { get; init; }
  }
}
