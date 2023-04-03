using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrud.Shared
{
    public class TipoDTO
    {
        public int IdTipo { get; set; }

        public string TipoMascota { get; set; } = null!;
    }
}
