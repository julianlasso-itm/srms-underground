using Shared.Application.Interfaces;

namespace Profiles.Application.Commands
{
  public class RegisterSkillCommand : ICommand
  {
    public object SkillId { get; init; }
    public string Name { get; init; }
  }
}
