using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Models;

namespace Analytics.Infrastructure.Persistence.Models;

[Index(nameof(Name), nameof(DeletedAt), IsUnique = true)]
[Table("tbl_level")]
public class LevelModel : AuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("rol_level_id")]
    public Guid LevelId { get; set; }

    [Required]
    [Column("rol_name")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Column("rol_description")]
    [MaxLength(1024)]
    public string? Description { get; set; }

    [Required]
    [Column("rol_disabled")]
    public bool Disabled { get; set; }
}
