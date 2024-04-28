using Profiles.Domain.Entities.Structs;

namespace Profiles.Domain.Aggregates.Dto.Requests
{
    public class UpdateProfessionalDomainResponse
    {
        public string ProfessionalId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Disabled { get; set; }
        public IEnumerable<SkillStruct> Skills { get; set; }
    }
}
