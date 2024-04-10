using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infrastructure.Persistence.Models;

[Index(nameof(UserId), nameof(RoleId), nameof(DeletedAt), IsUnique = true)]
[Table("tbl_user_per_role")]
public class UserPerRole
{
    [Required]
    [Column("upr_user_id")]
    public Guid UserId { get; set; }

    [Required]
    [Column("upr_role_id")]
    public Guid RoleId { get; set; }

    [Required]
    [Column("upr_created_at")]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("upr_deleted_at")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(ConvertEmptyStringToNull = true)]
    public DateTime? DeletedAt { get; set; }

    public required User User { get; set; }
    public required Role Role { get; set; }
}
