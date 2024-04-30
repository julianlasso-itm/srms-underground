using Shared.Application.Interfaces;

namespace AccessControl.Application.Commands
{
  public sealed class DeleteRoleCommand : ICommand
  {
    public required string RoleId { get; init; }
  }
}
