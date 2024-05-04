using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infrastructure.Persistence.Models
{
  [Index(nameof(UserId), nameof(RoleId), IsUnique = true)]
  [Table("user_per_role")]
  public class UserPerRoleModel
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("upr_id")]
    public Guid UserPerRoleId { get; set; }

    [Required]
    [ForeignKey(nameof(UserModel))]
    [Column("upr_user_id")]
    public Guid UserId { get; set; }

    [Required]
    [ForeignKey(nameof(RoleModel))]
    [Column("upr_role_id")]
    public Guid RoleId { get; set; }

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public UserModel User { get; set; }

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public RoleModel Role { get; set; }
  }
}
