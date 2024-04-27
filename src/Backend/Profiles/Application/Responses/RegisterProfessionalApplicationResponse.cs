
using Profiles.Domain.Entities;

namespace Profiles.Application.Responses
{
    public class RegisterProfessionalApplicationResponse
    {
        public string ProfessionalId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<SkillEntity> Skills { get; set; }
        public bool Disabled { get; set; }
    }
}
