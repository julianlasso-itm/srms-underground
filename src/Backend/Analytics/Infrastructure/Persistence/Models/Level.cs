using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Analytics.Infrastructure.Persistence.interfaces;
using Shared.Infrastructure.Persistence.Models;

namespace Analytics.Infrastructure.Persistence.Models
{

    [Table("tbl_level")]
    public class Level : AuditableEntity, IEntityWithName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("skl_level_id")]
        public Guid LevelId { get; set; }

        [Required]
        [Column("skl_name")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Column("skl_disabled")]
        public bool Disabled { get; set; } = false;
    }
}
