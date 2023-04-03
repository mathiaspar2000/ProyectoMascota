using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models;

public partial class Mascota
{
    public int IdMascota { get; set; }

    public string NombreMascota { get; set; } = null!;

    public string NombreDueño { get; set; } = null!;

    public int IdTipo { get; set; }

    public int Edad { get; set; }

    public int ValorPagar { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime FechaSalida { get; set; }

    public virtual Tipo IdTipoNavigation { get; set; } = null!;
}
