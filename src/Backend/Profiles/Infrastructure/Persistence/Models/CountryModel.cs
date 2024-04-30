using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Profiles.Infrastructure.Persistence.Models
{
  [Index(nameof(Name), IsUnique = true)]
  [Table("country")]
  public class CountryModel
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("ctr_country_id")]
    public Guid CountryId { get; set; }

    [Required]
    [Column("ctr_name")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [Column("ctr_disabled")]
    public bool Disabled { get; set; }

    [InverseProperty("Country")]
    public ICollection<ProvinceModel> Provinces { get; set; } = new List<ProvinceModel>();
  }
}
