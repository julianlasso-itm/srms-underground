using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence.Models
{
  [Index(nameof(Name), IsUnique = true)]
  [Table("squad")]
  public class SquadModel : AuditableEntity
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("sqd_squad_id")]
    public Guid SquadId { get; set; }

    [Required]
    [Column("sqd_name")]
    [MaxLength(20)]
    public string Name { get; set; }

    [Required]
    [Column("sqd_disabled")]
    public bool Disabled { get; set; } = false;

    [InverseProperty("Squad")]
    public ICollection<AssessmentModel> Assessments { get; set; } = new List<AssessmentModel>();
  }
}
