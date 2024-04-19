using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infrastructure.Persistence.Models;

[Index(nameof(Name), nameof(DeletedAt), IsUnique = true)]
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
    public string Name { get; set; }

    [Column("rol_description")]
    [MaxLength(1024)]
    public string? Description { get; set; }

    [Required]
    [Column("rol_disabled")]
    public bool Disabled { get; set; }

    [Column("rol_created_at")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(ConvertEmptyStringToNull = true)]
    public DateTime? CreatedAt { get; set; }

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
