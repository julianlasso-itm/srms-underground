using Shared.Application.Interfaces;

namespace AccessControl.Application.Commands
{
  public sealed class UpdateUserCommand : ICommand
  {
    public required string UserId { get; init; }
    public string? Name { get; set; }
    public string? Avatar { get; set; }
    public byte[]? AvatarBytes { get; set; }
    public string? AvatarExtension { get; set; }
    public bool? Disabled { get; set; }
  }
}
