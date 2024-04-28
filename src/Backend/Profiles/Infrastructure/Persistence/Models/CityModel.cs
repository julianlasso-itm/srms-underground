using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Profiles.Infrastructure.Persistence.Models;

[Index(nameof(Name), nameof(ProvinceId), IsUnique = true)]
[Table("city")]
public class CityModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("cty_city_id")]
    public Guid CityId { get; set; }

    [ForeignKey(nameof(ProvinceModel))]
    [Column("prv_province_id")]
    public Guid ProvinceId { get; set; }

    [Required]
    [Column("cty_name")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [Column("cty_disabled")]
    public bool Disabled { get; set; }

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public ProvinceModel Province { get; set; }
}
