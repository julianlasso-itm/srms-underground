using Shared.Application.Interfaces;

namespace AccessControl.Application.Commands
{
  public sealed class RegisterUserCommand : ICommand
  {
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string Avatar { get; set; }
  }
}
