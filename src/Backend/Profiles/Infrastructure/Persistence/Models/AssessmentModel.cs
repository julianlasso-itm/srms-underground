using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence.Models
{
  [Table("assessment")]
  public class AssessmentModel : AuditableEntity
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("asm_assessment_id")]
    public Guid AssessmentId { get; set; }

    [ForeignKey(nameof(ProfessionalModel))]
    [Column("prf_professional_id")]
    public Guid ProfessionalId { get; set; }

    [ForeignKey(nameof(RoleModel))]
    [Column("rol_role_id")]
    public Guid RoleId { get; set; }

    [ForeignKey(nameof(SquadModel))]
    [Column("sqd_squad_id")]
    public Guid SquadId { get; set; }

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public ProfessionalModel Professional { get; set; }

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public RoleModel Role { get; set; }

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public SquadModel Squad { get; set; }
  }
}
