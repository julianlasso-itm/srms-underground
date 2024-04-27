using Shared.Application.Interfaces;

namespace Analytics.Application.Commands;

public sealed class RegisterLevelCommand : ICommand
{
    public required string Name { get; init; }
    public string? Description { get; init; }
}
