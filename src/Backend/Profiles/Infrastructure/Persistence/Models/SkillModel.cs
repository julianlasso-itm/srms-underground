using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [Table("skill")]
    public class SkillModel : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("skl_skill_id")]
        public Guid SkillId { get; set; }

        [Required]
        [Column("skl_name")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Column("skl_disabled")]
        public bool Disabled { get; set; } = false;
    }
}
