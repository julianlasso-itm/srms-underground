using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence.Models
{
  [Table("result")]
  public class ResultModel : AuditableEntity
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("res_result_id")]
    public Guid ResultId { get; set; }

    [ForeignKey(nameof(AssessmentModel))]
    [Column("asm_assessment_id")]
    public Guid AssessmentId { get; set; }

    [ForeignKey(nameof(SubSkillModel))]
    [Column("sub_sub_skill_id")]
    public Guid SubSkillId { get; set; }

    [Column("res_result")]
    [Range(0, 5, ErrorMessage = "Result must be between 0 and 5")]
    public int Result { get; set; } = 0;

    [Column("res_comment")]
    [MaxLength(2048)]
    public string? Comment { get; set; }

    [Column("res_date_time")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(ConvertEmptyStringToNull = true)]
    public DateTime? DateTime { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public AssessmentModel Assessment { get; set; }

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public SubSkillModel SubSkill { get; set; }
  }
}
