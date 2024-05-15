using Shared.Application.Interfaces;

namespace AccessControl.Application.Commands
{
  public sealed class SignInCommand : ICommand
  {
    public required string Email { get; init; }
    public required string Password { get; init; }
  }
}
