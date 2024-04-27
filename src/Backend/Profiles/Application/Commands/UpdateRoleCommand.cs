using Shared.Application.Interfaces;

namespace Profiles.Application.Commands;

public sealed class UpdateRoleCommand : ICommand
{
    public required string RoleId { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public bool? Disable { get; init; }
}
