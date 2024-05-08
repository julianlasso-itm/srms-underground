using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Models;

namespace AccessControl.Infrastructure.Persistence.Models
{
  [Index(nameof(Email), nameof(DeletedAt), IsUnique = true)]
  [Index(nameof(Email), nameof(Password))]
  [Table("user")]
  public class UserModel : AuditableEntity
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("usr_user_id")]
    public Guid UserId { get; set; }

    [Required]
    [Column("usr_name")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [Column("usr_email")]
    [MaxLength(500)]
    public string Email { get; set; }

    [Required]
    [Column("usr_password")]
    [MaxLength(128)]
    public string Password { get; set; }

    [Required]
    [Column("usr_photo")]
    [MaxLength(500)]
    public string Photo { get; set; }

    [Required]
    [Column("usr_disabled")]
    public bool Disabled { get; set; } = false;

    [InverseProperty("User")]
    public ICollection<UserPerRoleModel> UserPerRoles { get; set; } = new List<UserPerRoleModel>();
  }
}
