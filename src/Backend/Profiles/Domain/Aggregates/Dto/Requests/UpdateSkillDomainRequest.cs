namespace Profiles.Domain.Aggregates.Dto.Requests
{
    public class UpdateSkillDomainRequest
    {
        public string? Name { get; init; }
        public bool? Disabled { get; init; }
        public required string SkillId { get; init; }
    }
}
