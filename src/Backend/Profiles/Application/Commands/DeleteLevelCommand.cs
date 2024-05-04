using Shared.Application.Interfaces;

namespace Profiles.Application.Commands
{
  public sealed class DeleteLevelCommand : ICommand
  {
    public required string LevelId { get; init; }
  }
}
