using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infrastructure.Persistence.Models;

[Index(nameof(UserId), nameof(RoleId), IsUnique = true)]
[Table("tbl_user_per_role")]
public class UserPerRoleModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("upr_id")]
    public Guid UserPerRoleId { get; set; }

    [Required]
    [Column("upr_user_id")]
    public Guid UserId { get; set; }

    [Required]
    [Column("upr_role_id")]
    public Guid RoleId { get; set; }

    public required UserModel User { get; set; }
    public required RoleModel Role { get; set; }
}
