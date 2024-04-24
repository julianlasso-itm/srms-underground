// Licensed to the .NET Foundation under one or more agreements.

using System.ComponentModel.DataAnnotations;
using Profiles.Infrastructure.Persistence.interfaces;

namespace Profiles.Infrastructure.Persistence.Models
{
    public class Country: IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "País")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public ICollection<State>? States { get; set; }

        [Display(Name = "Estados/Departamentos")]
        public int StatesNumber => States == null || States.Count == 0 ? 0 : States.Count;
    }
}
