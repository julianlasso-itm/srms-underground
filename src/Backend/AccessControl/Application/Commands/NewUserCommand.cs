using Shared.Application.Interfaces;

namespace AccessControl.Application.Commands;

public sealed class NewUserCommand : ICommand
{
    public required string Email { get; init; }
    public required string Password { get; init; }
    public List<string>? Roles { get; set; }
}
