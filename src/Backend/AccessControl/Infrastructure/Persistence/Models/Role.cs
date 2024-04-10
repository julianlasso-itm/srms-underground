using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infrastructure.Persistence.Models;

[Index(nameof(Name), IsUnique = true)]
[Index(nameof(RoleId), nameof(DeletedAt), IsUnique = true)]
[Table("tbl_role")]
public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("rol_role_id")]
    public Guid RoleId { get; set; }

    [Required]
    [Column("rol_name")]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    [Column("rol_disabled")]
    public required bool Disabled { get; set; } = false;

    [Required]
    [Column("rol_created_at")]
    [DataType(DataType.DateTime)]
    public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("rol_updated_at")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(ConvertEmptyStringToNull = true)]
    public DateTime? UpdatedAt { get; set; }

    [Column("rol_deleted_at")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(ConvertEmptyStringToNull = true)]
    public DateTime? DeletedAt { get; set; }

    public ICollection<UserPerRole> UserPerRoles { get; set; } = new List<UserPerRole>();
}
