using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Models;

namespace AccessControl.Infrastructure.Persistence.Models;

[Index(nameof(Name), nameof(DeletedAt), IsUnique = true)]
[Index(nameof(RoleId), nameof(DeletedAt), IsUnique = true)]
[Table("tbl_role")]
public class RoleModel : AuditableEntity
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

    public ICollection<UserPerRoleModel> UserPerRoles { get; set; } = new List<UserPerRoleModel>();
}
