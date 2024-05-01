using Shared.Application.Interfaces;

namespace QueryBank.Application.Commands
{
  public class RegisterSkillCommand : ICommand
  {
    public string SkillId { get; init; }
    public string? SubSkillId { get; init; }
    public string Name { get; init; }
    public bool Disable { get; init; }
  }
}
