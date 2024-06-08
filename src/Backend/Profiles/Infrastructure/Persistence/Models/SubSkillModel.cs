using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence.Models
{
  [Index(nameof(Name), nameof(SkillId), IsUnique = true)]
  [Table("subskill")]
  public class SubSkillModel : AuditableEntity
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("sbskl_subskill_id")]
    public Guid SubSkillId { get; set; }

    [ForeignKey(nameof(SkillModel))]
    [Column("skl_skill_id")]
    public Guid SkillId { get; set; }

    [Required]
    [Column("sbskl_name")]
    [MaxLength(500)]
    public string Name { get; set; }

    [Required]
    [Column("sbskl_disabled")]
    public bool Disabled { get; set; } = false;

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public SkillModel Skill { get; set; }

    [InverseProperty("SubSkill")]
    public ICollection<ResultModel> Results { get; set; } = new List<ResultModel>();
  }
}
