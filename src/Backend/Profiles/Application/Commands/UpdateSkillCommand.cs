namespace Profiles.Application.Commands
{
    public class UpdateSkillCommand
    {
        public required string SkillId { get; set; }
        public string? Name { get; set; }
        public bool? Disabled { get; set; }
    }
}
