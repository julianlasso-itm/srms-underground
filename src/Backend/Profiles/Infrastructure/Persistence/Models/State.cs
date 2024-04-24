using System.ComponentModel.DataAnnotations;
using Profiles.Infrastructure.Persistence.interfaces;

namespace Profiles.Infrastructure.Persistence.Models
{
    public class State: IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Estado/Departamento")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; } = null!;

        public int CountryId { get; set; }

        public Country? Country { get; set; }

        public ICollection<City>? Cities { get; set; }

        public int CitiesNumber => Cities == null || Cities.Count == 0 ? 0 : Cities.Count;
    }

}
