using System.Runtime.Serialization;

namespace Profiles.Application.Commands
{
    public class DeleteSkillCommand
    {
        public required string SkillId { get; set; }
    }
}
