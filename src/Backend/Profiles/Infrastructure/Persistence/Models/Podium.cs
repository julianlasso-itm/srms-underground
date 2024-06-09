using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence.Models
{
  [Table("podium")]
  public class PodiumModel : AuditableEntity
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("pdm_podium_id")]
    public Guid PodiumId { get; set; }

    [Required]
    [Column("pdm_name")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Column("pdm_email")]
    [MaxLength(100)]
    public string Email { get; set; }

    [Column("pdm_photo")]
    [MaxLength(1000)]
    public string Photo { get; set; }
  }
}
