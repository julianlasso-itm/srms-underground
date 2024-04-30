using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Infrastructure.Persistence.Models
{
  public abstract class AuditableEntity
  {
    [Required]
    [Column("created_at")]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(ConvertEmptyStringToNull = true)]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(ConvertEmptyStringToNull = true)]
    public DateTime? DeletedAt { get; set; }
  }
}
