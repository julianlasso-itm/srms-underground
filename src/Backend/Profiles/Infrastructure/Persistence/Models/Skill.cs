using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Profiles.Infrastructure.Persistence.interfaces;
using Shared.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence.Models
{

    [Table("tbl_skill")]
    public class Skill: AuditableEntity, IEntityWithName
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
