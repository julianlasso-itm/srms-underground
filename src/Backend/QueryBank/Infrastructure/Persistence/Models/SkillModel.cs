using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Models;

namespace QueryBank.Infrastructure.Persistence.Models
{
  [Index(nameof(SubSkillId), nameof(Name), IsUnique = true)]
  [Table("skill")]
  public class SkillModel : AuditableEntity
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("skl_skill_id")]
    public Guid SkillId { get; set; }

    [ForeignKey("SubSkill")]
    [Column("skl_sub_skill_id")]
    public Guid? SubSkillId { get; set; }

    [Required]
    [Column("skl_name")]
    [MaxLength(20)]
    public string Name { get; set; }

    [Required]
    [Column("skl_disabled")]
    public bool Disabled { get; set; } = false;

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual SkillModel SubSkill { get; set; }

    [InverseProperty("SubSkill")]
    public virtual ICollection<SkillModel> ParentSkills { get; set; } = new List<SkillModel>();
  }
}
