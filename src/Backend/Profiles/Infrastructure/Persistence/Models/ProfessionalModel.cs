using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence.Models
{
    [Table("professional")]
    public class ProfessionalModel : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("prf_professional_id")]
        public Guid ProfessionalId { get; set; }

        [Required]
        [Column("prf_name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column("prf_email")]
        [MaxLength(100)]
        public string Email { get; set; }

        public IEnumerable<SkillModel> Skills { get; set; } = new List<SkillModel>();

        public bool Disabled { get; set; } = false;
    }
}
