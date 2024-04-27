using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Profiles.Infrastructure.Persistence.interfaces;
using Shared.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence.Models
{
    public class Professional: AuditableEntity, IEntityWithName
    {
        [Key]
        public Guid ProfessionalId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public IEnumerable<Skill>Skills { get; set; } = new List<Skill>();

        public bool Disabled { get; set; } = false;
    }
}
