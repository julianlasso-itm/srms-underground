namespace Profiles.Application.Responses
{
    public class UpdateSkillApplicationResponse
    {
        public required string SkillId { get; set; }
        public string? Name { get; set; }
        public bool? Disabled { get; set; }
    }
}
