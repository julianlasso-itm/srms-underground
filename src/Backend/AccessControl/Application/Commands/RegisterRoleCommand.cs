using Shared.Application.Interfaces;

namespace AccessControl.Application.Commands;

public sealed class RegisterRoleCommand : ICommand
{
    public required string Name { get; init; }
    public string? Description { get; init; }
}
