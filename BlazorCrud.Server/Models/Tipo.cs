using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Tipo
{
    public int IdTipo { get; set; }

    public string TipoMascota { get; set; } = null!;

    public virtual ICollection<Mascota> Mascota { get; } = new List<Mascota>();
}
