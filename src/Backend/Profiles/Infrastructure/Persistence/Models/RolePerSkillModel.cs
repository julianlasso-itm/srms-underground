using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence.Models
{
  [Table("role_per_skill")]
  public class RolePerSkillModel : AuditableEntity
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("rps_role_per_skill_id")]
    public Guid RolePerSkillId { get; set; }

    [ForeignKey(nameof(RoleModel))]
    [Column("rol_role_id")]
    public Guid RoleId { get; set; }

    [ForeignKey(nameof(SkillModel))]
    [Column("ski_skill_id")]
    public Guid SkillId { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public RoleModel Role { get; set; }

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public SkillModel Skill { get; set; }
  }
}
