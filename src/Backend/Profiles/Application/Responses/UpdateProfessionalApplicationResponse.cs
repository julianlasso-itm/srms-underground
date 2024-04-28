using Profiles.Domain.Entities.Structs;

namespace Profiles.Application.Responses
{
    public class UpdateProfessionalApplicationResponse
    {
        public required string ProfessionalId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public IEnumerable<SkillStruct> Skills { get; set; }
        public bool Disabled { get; set; }
    }
}
