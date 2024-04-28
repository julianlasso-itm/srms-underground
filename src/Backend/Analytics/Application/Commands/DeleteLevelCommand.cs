using Shared.Application.Interfaces;

namespace Analytics.Application.Commands;

public sealed class DeleteLevelCommand : ICommand
{
    public required string LevelId { get; init; }
}
