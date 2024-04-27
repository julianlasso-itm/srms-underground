using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QueryBank.Infrastructure.Persistence.interfaces;
using Shared.Infrastructure.Persistence.Models;

namespace QueryBank.Infrastructure.Persistence.Models
{

    [Table("tbl_question")]
    public class Question : AuditableEntity, IEntityWithName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("skl_question_id")]
        public Guid QuestionId { get; set; }

        [Required]
        [Column("skl_name")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Column("skl_disabled")]
        public bool Disabled { get; set; } = false;
    }
}
