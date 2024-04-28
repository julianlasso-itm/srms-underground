namespace Profiles.Domain.Aggregates.Dto.Responses
{
    public class UpdateSkillDomainResponse
    {
        public string SkillId { get; internal set; }
        public string Name { get; internal set; }
        public bool Disabled { get; internal set; }
    }
}
