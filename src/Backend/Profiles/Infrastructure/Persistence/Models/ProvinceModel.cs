using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Profiles.Infrastructure.Persistence.Models;

[Index(nameof(Name), nameof(CountryId), IsUnique = true)]
[Table("province")]
public class ProvinceModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("prv_province_id")]
    public Guid ProvinceId { get; set; }

    [ForeignKey(nameof(CountryModel))]
    [Column("ctr_country_id")]
    public Guid CountryId { get; set; }

    [Required]
    [Column("prv_name")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [Column("prv_disabled")]
    public bool Disabled { get; set; }

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public CountryModel Country { get; set; }

    [InverseProperty("Province")]
    public ICollection<CityModel> Cities { get; set; } = new List<CityModel>();
}
