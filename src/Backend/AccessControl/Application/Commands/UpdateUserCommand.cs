using Shared.Application.Interfaces;

namespace AccessControl.Application.Commands
{
  public sealed class UpdateUserCommand : ICommand
  {
    public required string UserId { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }
    public bool? Disabled { get; init; }
  }
}
