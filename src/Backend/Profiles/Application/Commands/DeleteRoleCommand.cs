using Shared.Application.Interfaces;

namespace Profiles.Application.Commands;

public sealed class DeleteRoleCommand : ICommand
{
    public required string RoleId { get; init; }
}
