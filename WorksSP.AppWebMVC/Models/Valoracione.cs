using System;
using System.Collections.Generic;

namespace WorksSP.AppWebMVC.Models;

public partial class Valoracione
{
    public int Id { get; set; }

    public int IdPerfilTrabajo { get; set; }

    public int IdContratista { get; set; }

    public byte? Calificacion { get; set; }

    public string? Comentario { get; set; }

    public virtual Contratista IdContratistaNavigation { get; set; } = null!;

    public virtual PerfilTrabajo IdPerfilTrabajoNavigation { get; set; } = null!;
}
