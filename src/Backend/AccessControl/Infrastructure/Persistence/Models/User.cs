using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infrastructure.Persistence.Models;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(UserId), nameof(DeletedAt), IsUnique = true)]
[Table("tbl_user")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("usr_user_id")]
    public Guid UserId { get; set; }

    [Required]
    [Column("usr_email")]
    [MaxLength(500)]
    public required string Email { get; set; }

    [Required]
    [Column("usr_password")]
    [MaxLength(128)]
    public required string Password { get; set; }

    [Required]
    [Column("usr_disabled")]
    public required bool Disabled { get; set; } = false;

    [Required]
    [Column("usr_created_at")]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("usr_updated_at")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(ConvertEmptyStringToNull = true)]
    public DateTime? UpdatedAt { get; set; }

    [Column("usr_deleted_at")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(ConvertEmptyStringToNull = true)]
    public DateTime? DeletedAt { get; set; }

    public ICollection<UserPerRole> UserPerRoles { get; set; } = new List<UserPerRole>();
}
