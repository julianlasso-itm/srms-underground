using Shared.Application.Interfaces;

namespace Profiles.Application.Commands
{
  public class RegisterSkillCommand : ICommand
  {
    public string Name { get; init; }
    public object SkillId { get; init; }
  }
}
