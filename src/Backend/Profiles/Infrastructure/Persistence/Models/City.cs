using System.ComponentModel.DataAnnotations;
using Profiles.Infrastructure.Persistence.interfaces;
using Shared.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence.Models
{
    public class City: AuditableEntity, IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; } = null!;

        public int StateId { get; set; }

        public State? State { get; set; }


    }
}
