using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.Shared
{
    public class MascotaDTO
    {
        public int IdMascota { get; set; }

        [Required(ErrorMessage ="El campo{0} es requerido")]
        public string NombreMascota { get; set; } = null!;

        [Required(ErrorMessage = "El campo{0} es requerido")]
        public string NombreDueño { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0} es requerido.")]
        public int IdTipo { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0} es requerido.")]
        public int Edad { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0} es requerido.")]
        public int ValorPagar { get; set; }

        public DateTime FechaIngreso { get; set; }

        public DateTime FechaSalida { get; set; }

        public TipoDTO? Tipo { get; set; } 
    }
}
